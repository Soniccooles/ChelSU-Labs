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
	cout << "BigEndian: " << str2 << endl;
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
	cout << "BigEndian: " << str2 << endl;
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
	cout << "BigEndian: " << str2 << endl;

}
void main()
{
	setlocale(LC_ALL, "Rus");
	cout << "Введите число: ";
	double x;
	cin >> x;
	int firstTest = x;
	float secondTest = x;
	double thirdTest = x;
	cout << "Вы ввели число " << firstTest << endl;
	ShowAllBytes(firstTest);
	ShowAllBytes(secondTest);
	ShowAllBytes(thirdTest);
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
//        front = rear = 0; // Создание структуры, которая будет содержать в себе следующие (front) значения и предыдущие (rear)
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
//    queue A;
//    A.push(6);
//    A.push(2);
//    A.push(7);
//    A.push(1);
//
//    cout << A.pop();
//    cout << A.pop();
//    cout << A.pop();
//    cout << A.pop();
//    return 0;
//}
////////class BoolArray
////////{
////////    
////////    public:
////////        BoolArray(int size)
////////        {
////////            
////////        }
////////        bool Get(int i)
////////        {
////////
////////        }
////////        void Set(int i, bool value)
////////        {
////////            
////////        }
////////};
////////int main()
////////{
////////    BoolArray* array;
////////    array->Set(1, false);
////////    array->Set(0, true);
////////    array->Set(2, false);
////////    array->Set(3, false);
////////
////////}