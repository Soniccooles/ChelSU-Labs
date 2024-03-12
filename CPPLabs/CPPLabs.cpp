#include <iostream>;
using namespace std;
string ShowByte(unsigned char *c) // принимает указатель
{
	string str = "";
	int i;
	for (int i = 0; i < 8; i++) // цикл от 0 до 8 не включительно
	{
		if (*c & (0x80 >> i)) str += "1"; //если 
		else str += "0";
	}
	return str;
};
void ShowAllBytes(int b)
{
	string str1 = "", str2 = "";

	for (int i = 0; i <= 3; i++)
	{
		str1 += ShowByte(((unsigned char*)&b)+i);
		str2 += ShowByte(((unsigned char*)&b) + (3 - i));
	}
	cout << "\n" "int" << endl;
	cout <<"\n" "Little Endian: " << str1 << endl;
	cout << "Big Endian: " << str2 << endl;
};
void ShowAllBytes(float b)
{
	string str1 = "", str2 = "";

	for (int i = 0; i <= 3; i++)
	{
		str1 += ShowByte(((unsigned char*)&b) + i);
		str2 += ShowByte(((unsigned char*)&b) + (3 - i));
	}

	cout << "\n" "float" << endl;
	cout << "\n" "Little Endian: " << str1 << endl;
	cout << "Big Endian: " << str2 << endl;
}
void ShowAllBytes(double b)
{
	string str1 = "", str2 = "";

	for (int i = 0; i <= 7; i++)
	{
		str1 += ShowByte(((unsigned char*)&b) + i);
		str2 += ShowByte(((unsigned char*)&b) + (7 - i));
	}

	cout <<"\n" "double" << endl;
	cout << "\n" "Little Endian: " << str1 << endl;
	cout << "Big Endian: " << str2 << endl;

}
void main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Введите число: ";
	double x;
	cin >> x;
	int firsttest = x;
	float secondtest = x;
	double thirdtest = x;
	cout << "Вы ввели число " << firsttest << endl;
	ShowAllBytes(firsttest);
	ShowAllBytes(secondtest);
	ShowAllBytes(thirdtest);
};










//typedef struct _qe
//{
//    int data;
//    _qe* next;
//}qe;
//class queue
//{
//    qe *front, *rear;
//public:
//    queue()
//    {
//        front = rear = 0; // создание структуры, которая будет содержать в себе следующие (front) значения и предыдущие (rear)
//    }
//    void push(int data)
//    {
//        qe* elem = new qe;
//        elem->data = data;
//        elem->next = 0;
//        if (!front)
//        {
//            front = rear = elem;
//        }
//        else
//        {
//            rear->next = elem;
//            rear = elem;
//        }
//    }
//
//    int pop()
//    {
//        if (!front) return 0;
//        int data = front->data;
//        qe *elem = front;
//        front = front->next;
//        delete elem;
//        return data;
//    }
//};
//int main()
//{
//    queue a;
//    a.push(6);
//    a.push(2);
//    a.push(7);
//    a.push(1);
//
//    cout << a.pop();
//    cout << a.pop();
//    cout << a.pop();
//    cout << a.pop();
//    return 0;
//}
//class boolarray
//{
//    
//    public:
//        boolarray(int size)
//        {
//            
//        }
//        bool get(int i)
//        {
//
//        }
//        void set(int i, bool value)
//        {
//            
//        }
//};
//int main()
//{
//    boolarray* array;
//    array->set(1, false);
//    array->set(0, true);
//    array->set(2, false);
//    array->set(3, false);
//
//}