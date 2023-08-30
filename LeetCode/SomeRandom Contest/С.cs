class RandomC
{
    private class Country
    {
        public int index;
        public int minIncome;
        public int higherEducation;
        public int childrenAllowed;
    }

    private class Student
    {
        public int index;
        public int income;
        public int education;
        public int parentsCitizenship;
    }

    static void TaskC()
    {
        int countriesAmount = int.Parse(Console.ReadLine()!);
        Country[] countries = new Country[countriesAmount];
        {
            int[] minIncome = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int[] higherEducation = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int[] childrenAllowed = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int i = 0; i < countriesAmount; i++)
            {
                countries[i] = new Country
                {
                    index = i,
                    minIncome = minIncome[i],
                    higherEducation = higherEducation[i],
                    childrenAllowed = childrenAllowed[i]
                };
            }
        }
        var dMinIncomeToMinIdxCountryNoEducation = new SortedDictionary<int, int>();
        var dMinIncomeToMinIdxCountryWithEducation = new SortedDictionary<int, int>();
        foreach (Country country in countries)
        {
            if (country.higherEducation == 1)
            {
                if (dMinIncomeToMinIdxCountryWithEducation.ContainsKey(country.minIncome))
                {
                    dMinIncomeToMinIdxCountryWithEducation[country.minIncome] =
                        Math.Min(dMinIncomeToMinIdxCountryWithEducation[country.minIncome], country.index);
                }
                else
                {
                    dMinIncomeToMinIdxCountryWithEducation[country.minIncome] = country.index;
                }
            }
            else
            {
                if (dMinIncomeToMinIdxCountryNoEducation.ContainsKey(country.minIncome))
                {
                    dMinIncomeToMinIdxCountryNoEducation[country.minIncome] =
                        Math.Min(dMinIncomeToMinIdxCountryNoEducation[country.minIncome], country.index);
                }
                else
                {
                    dMinIncomeToMinIdxCountryNoEducation[country.minIncome] = country.index;
                }
            }
        }

        var countriesRequiredEducation = countries.Where(country => country.higherEducation == 1).ToList();
        var countriesAllowedChildren = countries.Where(country => country.childrenAllowed == 1).ToList();

        int studentsAmount = int.Parse(Console.ReadLine()!);
        Student[] students = new Student[studentsAmount];
        {
            int[] incomes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int[] education = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int[] parentsCitizenship = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int i = 0; i < studentsAmount; i++)
            {
                students[i] = new Student
                {
                    index = i,
                    income = incomes[i],
                    education = education[i],
                    parentsCitizenship = parentsCitizenship[i] - 1
                };
            }
        }

        List<int> ans = new List<int>();

        for (int i = 0; i < studentsAmount; i++)
        {
            int chosenCountry = int.MaxValue;

            if (students[i].parentsCitizenship != -1)
            {
                if (countries[students[i].parentsCitizenship].childrenAllowed == 1)
                {
                    chosenCountry = Math.Min(chosenCountry, students[i].parentsCitizenship);
                }
            }

            {
                var availableByIncome = dMinIncomeToMinIdxCountryNoEducation
                    .Where((pair => students[i].income > pair.Key))
                    .ToList();
                if (availableByIncome.Count != 0)
                {
                    chosenCountry = Math.Min(chosenCountry, availableByIncome[i].Value);
                }
            }

            if (students[i].education == 1)
            {
                var availableByIncome = dMinIncomeToMinIdxCountryWithEducation
                    .Where((pair => students[i].income > pair.Key))
                    .ToList();
                if (availableByIncome.Count != 0)
                {
                    chosenCountry = Math.Min(chosenCountry, availableByIncome[i].Value);
                }
            }

            ans.Add(chosenCountry == int.MaxValue ? 0 : chosenCountry + 1);
        }

        Console.WriteLine(string.Join(" ", ans.Select(val => val.ToString()).ToArray()));
    }
}