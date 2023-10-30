#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

class Data {
	int dia, mes, ano;

	public:
	
		void setDia(int _dia){
			this -> dia = _dia;
		}
		int getDia(){
			return dia;
		}
		void setMes(int _mes){
			this -> mes = _mes;
		}
		int getMes(){
			return mes;
		}
		void setAno(int _ano){
			this -> ano = _ano;
		}
		int getAno(){
			return ano;
		}
		/*
		O m�todo abaixo retornar� -1 se d1 � anterior a d2
		Retornar� 0 se d1 = d2
		Retornar� +1 se d1 � posterior a d2
		*/	
		static int compara(Data d1, Data d2) { 
			
			if(d1.getAno() < d2.getAno()){
				return -1;
			}else if (d1.getAno() > d2.getAno()){
				return +1;
			}else if (d1.getAno() == d2.getAno()){
				if (d1.getMes() == d2.getMes()){
					if (d1.getDia() == d2.getDia()){
						return 0;
					}else if (d1.getDia() < d2.getDia()){
						return -1;
					}else if (d1.getDia() > d2.getDia()){
						return +1;
					}		
				}else if (d1.getMes() < d2.getMes()){
					return -1;
				}else if (d1.getMes() > d2.getMes()){
					return +1;
				}
			}


			return 0;
		}
		
		Data (int _dia, int _mes, int _ano) {
			dia = _dia;
			mes = _mes;
			ano = _ano;
		}
		string toString() {
			string ret = "";
			ret.append(to_string(dia));
			ret.append("/");
			ret.append(to_string(mes));
			ret.append("/");
			ret.append(to_string(ano));
			return ret;
		}
};

class Lista {
	public:
	virtual void entradaDeDados() =0;
	virtual void mostraMediana() =0;
	virtual void mostraMenor() =0;
	virtual void mostraMaior() =0;
};

class ListaNomes {
	vector<string> lista;
	
	public:
	
	/*
	O m�todo abaixo pergunta ao usu�rios quantos
	elementos v�o existir na lista e depois
	solicita a digita��o de cada um deles
	*/	
	void entradaDeDados() {
		lista.push_back("Teste");
	}
		
	void mostraMediana() {
		cout << "Aqui vai mostrar a mediana da lista de strings" << endl;
	}
	
	void mostraMenor() {
		cout << "Aqui vai mostrar o primeiro nome alfabeticamente" << endl;
	}
	void mostraMaior() {
		cout << "aqui vai mostrar o ultimo nome alfabeticamente" << endl;
	}
};

class ListaDatas : public Lista {
	vector<Data> lista;

	public:
		/*
		O m�todo abaixo pergunta ao usu�rios quantos
		elementos v�o existir na lista e depois
		solicita a digita��o de cada um deles
		*/	
		void entradaDeDados() {
			int QtdLista, _dia, _mes, _ano;

			cout << "Informe quantas datas você gostaria der inserir na lista: ";
			cin >> QtdLista;

			for(int i = 0; i != QtdLista; i++){

				cout << "Informe uma data: \n" << endl;
				cout << "Dia: ";
				cin >> _dia;
				cout << "Mês: ";
				cin >> _mes;
				cout << "Ano: ";
				cin >> _ano;

				Data *novaData = new Data(_dia, _mes, _ano); 

				lista.push_back(*novaData);
			}

			int i, j;
			
			Data *checkData = new Data(0, 0, 0);
			for (i = 0 ; i < QtdLista - 1 ; i++){
				for (j = 0; j < QtdLista - i - 1; j++) {
					if (checkData->compara(lista[j] , lista[j + 1]) == 1) {
						swap(lista[j], lista[j + 1]);
					}	
				} 
			}
			delete checkData;
		}
		
		void mostraMediana() {
			vector <Data> :: iterator at = lista.begin();
			at += lista.size()/2;
			if(lista.size() % 2 == 0){
				at--;
			}
			cout << "A mediana das datas é: " << at -> toString() << endl;

		}
		
		void mostraMenor() {
			vector <Data> :: iterator at = lista.begin();

			cout << "A menor data da lista: " << at -> toString() << endl;

			
		}
		void mostraMaior() {
			vector <Data> :: reverse_iterator at = lista.rbegin();

			cout << "A maior data da lista: " << at -> toString() << endl;
		}
};

class ListaSalarios  {
	vector<float> lista;
	
	public:
	
	/*
	O m�todo abaixo pergunta ao usu�rios quantos
	elementos v�o existir na lista e depois
	solicita a digita��o de cada um deles
	*/	
	void entradaDeDados() {
		
	}
			
	void mostraMediana() {
		cout << "Aqui vai mostrar a mediana da lista de salarios" << endl;
	}
	
	void mostraMenor() {
		cout << "Aqui vai mostrar o menor dos salarios" << endl;
	}
	void mostraMaior() {
		cout << "aqui vai mostrar o maior dos salarios" << endl;
	}
};


class ListaIdades  {
	vector<int> lista;
	
	public:
		
		/*
	O m�todo abaixo pergunta ao usu�rios quantos
	elementos v�o existir na lista e depois
	solicita a digita��o de cada um deles
	*/	
	void entradaDeDados() {
		
	}
	
	void mostraMediana() {
		cout << "Aqui vai mostrar a mediana da lista de idades" << endl;
	}
	
	void mostraMenor() {
		cout << "Aqui vai mostrar a menor das idades" << endl;
	}
	void mostraMaior() {
		cout << "aqui vai mostrar a maior das idades" << endl;
	}
};
 
int main () {
	vector<Lista*> listaDeListas;
	
	ListaNomes listaNomes;
	listaNomes.entradaDeDados();
	listaDeListas.push_back(&listaNomes);
	
	ListaDatas listaDatas;
	listaDatas.entradaDeDados();
	listaDeListas.push_back(&listaDatas);
	
	ListaSalarios listaSalarios;
	listaSalarios.entradaDeDados();
	listaDeListas.push_back(&listaSalarios);
	
	ListaIdades listaIdades;
	listaIdades.entradaDeDados();
	listaDeListas.push_back(&listaIdades);
	
	for (Lista* l : listaDeListas) {
		l->mostraMediana();
		l->mostraMenor();
		l->mostraMaior();
	}
	
}
    

