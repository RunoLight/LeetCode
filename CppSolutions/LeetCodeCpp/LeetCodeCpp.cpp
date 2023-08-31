#include <vector>



 struct ListNode {
     int val;
     ListNode *next;
     ListNode() : val(0), next(nullptr) {}
     ListNode(int x) : val(x), next(nullptr) {}
     ListNode(int x, ListNode *next) : val(x), next(next) {}
 };
 
class Solution {
public:
    ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
        vector<int> firstVec;
        vector<int> secondVec;

        firstVec.push_back(l1->val);
        secondVec.push_back(l2->val);
        while (l1->next != nullptr)
        {
            l1 = l1->next;
            firstVec.push_back(l1->val);
        }
        while (l2->next != nullptr)
        {
            l2 = l2->next;
            secondVec.push_back(l2->val);
        }
        reverse(firstVec.begin(), firstVec.end());
        reverse(secondVec.begin(), secondVec.end());
        unsigned long long a = 0;
        unsigned long long b = 0;
        for (int i = 0; i < firstVec.size(); i++)
        {
            a = a * 10 + firstVec[i];
        }
        for (int i = 0; i < secondVec.size(); i++)
        {
            b = b * 10 + secondVec[i];
        }

        unsigned long long c = a + b;

        std::cout << a << " " << b << " " << c;

        vector<int> v;
       
        if (c == 0)
        {
            return new ListNode(0);
        }
        
        while (c != 0) {
            v.push_back(c % 10);
            c /= 10;
        }
        //reverse(v.begin(), v.end());

        ListNode *result = new ListNode(v[0]);
        ListNode *tail = result;

        for (int i = 1; i < v.size(); i++)
        {
            ListNode* newTail = new ListNode(v[i]);
            tail->next = newTail;
            tail = newTail;
        }

        return result;
    }
};

#include <iostream>

using namespace std;

int main()
{
    std::cout << "Hello World!\n";

    
    
}
