//int main()
//{
//    int a = 1, b = 2, c = 3, d = 88, e = -2, x;
//    __asm
//    {
//        mov eax, a
//        add eax, b
//        imul c
//        sub eax, d
//        cdq
//        idiv e
//        mov x, eax
//    }
//    cout << x;
//    return 0;
//}
//int main()
//{
//	setlocale(LC_ALL, "RU");
//	int a, b;
//	int c;
//	cout << "������� ����� a = "; cin >> a; cout << endl;
//	cout << "������� ����� b = "; cin >> b; cout << endl;
//	unsigned char f, g;
//	f = (unsigned char)a;
//	g = (unsigned char)b;
//	bool isSignedOverflow, isUnsignedOverflow;
//	__asm
//	{
//		mov isSignedOverflow, 1
//		mov isUnsignedOverflow, 1
//		mov al, f
//		mov bl, g
//		add al, bl
//		jc label1;
//		mov isUnsignedOverflow, 0
//		label1:
//		jo label2;
//		mov isSignedOverflow, 0
//			label2:
//	}
//	int unsignedValue = (unsigned char)(a + b);
//	int signedValue = (char)((char)a + (char)b);
//	cout << "�������� �� ������: " << unsignedValue << endl;
//	cout << "����������� ��������: " << signedValue << endl;
//	if (isSignedOverflow)
//		cout << "������������ �� ������. ������� � �������� ������ - " << signedValue << endl;
//	if (isUnsignedOverflow)
//		cout << "����������� ������������. ������� �� ������� ��������� ����� - " << unsignedValue << endl;
//	return 0;
//}
#include <iostream>
#include <stdio.h>

using namespace std;
int main()
{
    int x = 5;
    __asm
    {
        push x
        call fact1
        add esp, 4
        mov x, eax
        jmp exit1
        fact1 :
        cmp [esp + 4], 1
            jg fact_calc
            mov eax, 1
            ret
            fact_calc :
        push[esp + 4]
            dec[esp]
            call fact1
            add esp, 4
            mul[esp + 4]
            ret
            exit1 :
    }
    cout << x << endl;
    return 0;
    
}
