// Колода состоит из 52 карт. Каждая карта обозначается одним из тринадцати значений (2, 3, 4, 5, 6, 7, 8, 9, Ten, Jack, Queen, King, Ace) и одной из четырех мастей (Spades, Clubs, Diamonds, Hearts).
//
// Выдуманная игра 3-Покер происходит следующим образом.
//
// 1) Изначально все n игроков получают по две карты из колоды.
// 2) После этого на стол выкладывается одна карта из той же колоды.
// 3) Выигрывают те игроки, у которых собралась самая старшая комбинация.
//     
// Для определения самой старшей комбинации, которая собралась у i -го игрока, используются следующие правила:
// * если две карты у игрока в руке и карта на столе имеют одинаковое значение, игрок собрал комбинацию 'Сет со значением x';
// * если из двух карт у игрока в руке и карты на столе можно выбрать две карты с одинаковым значением x, игрок собрал комбинацию 'Пара со значением x';
// * иначе, берется карта с самым старшим значением из двух карт у игрока в руке и карты на столе, тогда игрок собрал комбинацию 'Старшая карта x'.
// Любой сет старше пары, а любая пара старше комбинации старшая карта. Из одинаковых комбинаций старше та, у которой старше значение. Если одинаковая самая старшая комбинация есть у нескольких игроков, все они объявляются выигрывшими.
//
// Вы — первый игрок. Вам известно, какие карты получил на руки каждый игрок. Определите, какую карту можно выложить на стол, чтобы вы оказались в числе победителей.
//
// Входные данные
// Каждый тест состоит из нескольких наборов входных данных. Первая строка содержит целое число t(1≤t≤10^3) — количество наборов входных данных. Далее следует описание наборов входных данных.
//
// Первая строка каждого набора входных данных содержит целое число n(2≤n≤25) — количество игроков.
//
// Следующие n строк каждого набора входных данных содержат описания двух карт, разделенных пробелом — карты, которые получил на руки i -й игрок.
//
// Описание карты состоит из двух символов, записанных подряд: значения и масти.
//
// Выходные данные Для каждого набора входных данных выведите в первой строке количество карт k, которые можно выложить на стол для вашей победы. В следующих k строках выведите описания этих карт. Выводить описания можно в любом порядке.
//  
// Тест №1:
// Входные данные:
// 4
// 2
// TS TC
// AD AH
// 3
// 2H 3H
// 9S 9C
// 4D QS
// 3
// 4C 7H
// 4H 4D
// 6S 6H
// 3
// 2S 3H
// 2C 2D
// 3C 3D
//
// Выходные данные:
// 2
// TD
// TH
// 0
// 3
// 7S
// 7C
// 7D
// 0
//
// Тест №2:
// Входные данные:
// 1
// 7
// AS AC
// AD AH
// KS JH
// 9D 9C
// 5H 5D
// 3C 3S
// TC TH
//
// Выходные данные:
// 30
// 2S
// 2C
// 2D
// 2H
// 4S
// 4C
// 4D
// 4H
// 6S
// 6C
// 6D
// 6H
// 7S
// 7C
// 7D
// 7H
// 8S
// 8C
// 8D
// 8H
// JS
// JC
// JD
// QS
// QC
// QD
// QH
// KC
// KD
// KH

namespace LeetCode.Ozon_Route_256_Middle_Contest_2023;

using System.Text;

public static class TaskG
{
    public static void G()
    {
        int t = int.Parse(Console.ReadLine()!);
        StringBuilder answer = new StringBuilder();
        for (int i = 0; i < t; i++)
        {
            Poker(answer);
        }

        Console.Write(answer.ToString().Trim());
    }

    private static void Poker(StringBuilder answer)
    {
        int players = int.Parse(Console.ReadLine()!);
        List<Card> deck = (from value in Card.Values from suit in Card.Suits select new Card(value, suit)).ToList();

        Player me = new Player(new Card("A", "S"), new Card("A", "S")); // Preventing possible un-initialed
        List<Player> otherPlayers = new List<Player>();

        for (int j = 0; j < players; j++)
        {
            string[] cardInfo = Console.ReadLine()!.Split();
            Card card1 = deck.First(card =>
                card.Value.Equals(cardInfo[0][0].ToString()) && card.Suit.Equals(cardInfo[0][1].ToString()));
            Card card2 = deck.First(card =>
                card.Value.Equals(cardInfo[1][0].ToString()) && card.Suit.Equals(cardInfo[1][1].ToString()));

            deck.Remove(card1);
            deck.Remove(card2);

            if (j == 0)
            {
                me = new Player(card1, card2);
            }
            else
            {
                otherPlayers.Add(new Player(card1, card2));
            }
        }

        List<Card> winningCards = new List<Card>();
        foreach (Card card in deck)
        {
            (CombinationType type, int value) = me.GetCombination(card);
            bool otherPlayerWon = false;

            foreach (Player otherPlayer in otherPlayers)
            {
                (CombinationType otherType, int otherValue) = otherPlayer.GetCombination(card);
                if (otherType > type || (otherType == type && otherValue > value))
                {
                    otherPlayerWon = true;
                    break;
                }
            }

            if (!otherPlayerWon)
            {
                winningCards.Add(card);
            }
        }

        answer.AppendLine(winningCards.Count.ToString());
        foreach (var card in winningCards)
            answer.AppendLine($"{card.Value}{card.Suit}");
    }
}

internal class Player
{
    public Player(Card first, Card second)
    {
        _cards = new Card[2];
        _cards[0] = first;
        _cards[1] = second;
    }

    private readonly Card[] _cards;

    public (CombinationType type, int valueIndex) GetCombination(Card card)
    {
        CombinationType type;
        int valueIndex;

        var a = _cards.Append(card).ToList();
        if (a[0].Value.Equals(a[1].Value) && a[1].Value.Equals(a[2].Value))
        {
            type = CombinationType.Triple;
            valueIndex = Card.CardsList.IndexOf(card.Value);
        }
        else if (a[0].Value.Equals(a[1].Value))
        {
            type = CombinationType.Double;
            valueIndex = Card.CardsList.IndexOf(a[0].Value);
        }
        else if (a[1].Value.Equals(a[2].Value))
        {
            type = CombinationType.Double;
            valueIndex = Card.CardsList.IndexOf(a[1].Value);
        }
        else if (a[0].Value.Equals(a[2].Value))
        {
            type = CombinationType.Double;
            valueIndex = Card.CardsList.IndexOf(a[2].Value);
        }
        else
        {
            type = CombinationType.One;
            valueIndex = new List<int>
            {
                Card.CardsList.IndexOf(a[0].Value),
                Card.CardsList.IndexOf(a[1].Value),
                Card.CardsList.IndexOf(a[2].Value)
            }.Max();
        }

        return (type, valueIndex);
    }
}

enum CombinationType
{
    Triple = 3,
    Double = 2,
    One = 1
}

class Card
{
    public static readonly List<string> CardsList;
    public static readonly string[] Values = { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };
    public static readonly string[] Suits = { "S", "C", "D", "H" };

    public string Value { get; }
    public string Suit { get; }

    static Card()
    {
        CardsList = Values.ToList();
    }

    public Card(string value, string suit)
    {
        Value = value;
        Suit = suit;
    }
}