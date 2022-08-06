#include <iostream>
using namespace std;
int main()
{
	int camila, cibele, celeste;
	cin>>camila;
	cin>>cibele;
	cin>>celeste;
	if((5>camila || camila>100) || (5>cibele || cibele>100) || (5>celeste || celeste>100))
	{
		cout<<"Idade nao reconhecida, apenas valores entre 5 e 100"<<endl;
	}
		else 
		{ 
			cout<<camila<<endl;
		}
	
	system("pause");
	return 0;
}
