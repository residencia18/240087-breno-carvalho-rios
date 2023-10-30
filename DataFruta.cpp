#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <cmath>

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
	virtual void listarEmOrdem() =0;
	virtual void listaNElementos(int n) =0;
};

class ListaNomes : public Lista {
	vector<string> lista;
	
	public:
	
	/*
	O método abaixo pergunta ao usuário quantos
	elementos vão existir na lista e depois
	solicita a digitação de cada um deles
	*/	
	void entradaDeDados() {
		string _nome;
		int _qtdElementos;
		cout << "Quantos elementos vão existir na lista?" << endl;
		cin >> _qtdElementos;

		for(int i = 0; i < _qtdElementos; i++){
			cout << "Digite o nome " << (i + 1) << ": " << endl;
			getline(cin >> ws, _nome);
			lista.push_back(_nome);
		}
		sort(lista.begin(), lista.end());
		cout << "-----------------" << endl;
	}
		
	void mostraMediana() {
		float meio = floor(((this->lista.size() + 1) / 2.0) - 1);

		cout << "A mediana da lista de nomes é: " << endl;
		cout << this->lista.at(meio) << endl;
		cout << "-----------------" << endl;
	}
	
	void mostraMenor() {	
		cout << "O primeiro nome em ordem alfabética é: " << endl;
		cout << this->lista.front() << endl;
		cout << "-----------------" << endl;
	}

	void mostraMaior() {
		cout << "O ultimo nome em ordem alfabética é: " << endl;
		cout << this->lista.back() << endl;
		cout << "-----------------" << endl;
	}

	void listarEmOrdem(){
		cout << "A lista de nomes em ordem alfabética é: " << endl;
		for(auto nome: this->lista){
			cout << nome << endl;
		}
		cout << "-----------------" << endl;
	}

	void listaNElementos(int n){
		if(n > this->lista.size()){
			cout << "Número de elementos solicitados excede o tamanho da lista, mostrando todos os elementos..." << endl;
			n = this->lista.size();
		}
		cout << "Os " << n << " primeiros nomes da lista são: " << endl;
		for(int i = 0; i < n; i++){
			cout << (i + 1) << ". " << this->lista.at(i) << endl;
		}
		cout << "-----------------" << endl;
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
		int _n;

		l->mostraMediana();
		l->mostraMenor();
		l->mostraMaior();
		l->listarEmOrdem();

		cout << "Quantos elementos você quer mostrar?" << endl;
		while(true){
			cin >> _n;
			if(_n > 0){
				l->listaNElementos(_n);
				break;
			}
			cout << "O número de elementos mostrados deve ser maior do que zero!" << endl;
		}
	}
	
}
    

