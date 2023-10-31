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

		void validaData(){
			int _dia, _mes, _ano;

			cout << "\nInforme uma data: \n" << endl;
			cout << "Dia: ";
			cin >> _dia;
			while(!auxDia(_dia)){
				cout << "\nDia informado não é válido, por favor informe um dia válido! " << endl;
                cout << "Dia: ";
				cin >> _dia;
			}
			cout << "Mês: ";
			cin >> _mes;
			while(!auxMes(_mes)){
				cout << "\n Mês informado não é válido, por favor informe um mês válido: " << endl;
                cout << "Mês: ";
				cin >> _mes;				
			}
            while(!auxDiaMes(_dia, _mes)){
					cout << "\n Data informada até o momento não é válida, por favor informe uma data válida! \n" << endl;
					cout << "Dia: ";
					cin >> _dia;
					while(!auxDia(_dia)){
						cout << "\n Dia informado não é válido, por favor informe um dia válido! \n" << endl;
                        cout << "Dia: ";
						cin >> _dia;
					}
					cout << "Mês: ";
					cin >> _mes;
                    while(!auxMes(_mes)){
                        cout << "\n Mês informado não é válido, por favor informe um mês válido! \n" << endl;
                        cout << "Mês: ";
                        cin >> _mes;				
                    }				
				}
			cout << "Ano: ";
			cin >> _ano;
			while(!auxAno(_ano)){
				cout << "\n Ano informado não é válido, por favor informe um ano válido! \n" << endl;
                cout << "Ano: ";
				cin >> _ano;
			}

			this -> dia = _dia;
            this -> mes = _mes;
            this -> ano = _ano;

		}

        bool auxDia(int _dia){
            if(_dia < 1 || _dia > 31){
                return false;
            }else{
                return true;
            }
        }

        bool auxDiaMes(int _dia, int _mes){
            if((_dia == 31) && ((_mes == 4) || (_mes == 6) || (_mes == 9) || (_mes == 11))){
                return false;
            }else if(_dia > 29 && _mes == 2){
                return false;
            }else{
                return true;
            }
        }

        bool auxMes(int _mes){
            if(_mes < 1 || _mes > 12){
                return false;
            }else{
                return true;
            }
            
        }

        bool auxAno(int _ano){
            if(_ano < 1900 || _ano > 2023){
                return false;
            }else{
                return true;
            }
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
		int meio = floor(((this->lista.size() + 1) / 2.0) - 1);

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
			int QtdLista;

			cout << "Informe quantas datas você gostaria der inserir na lista: ";
			cin >> QtdLista;

			for(int i = 0; i != QtdLista; i++){

				Data *novaData = new Data(0, 0, 0); 

				novaData->validaData();

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
			cout << "A mediana das datas em ordem cronológica é: " << at -> toString() << endl;

		}
		
		void mostraMenor() {
			vector <Data> :: iterator at = lista.begin();

			cout << "A menor data da lista em ordem cronológica é: " << at -> toString() << endl;

			
		}
		void mostraMaior() {
			vector <Data> :: reverse_iterator at = lista.rbegin();

			cout << "A maior data da lista em ordem cronológica é: " << at -> toString() << endl;
		}

		void listarEmOrdem(){
			cout << "A lista de datas em ordem cronológica é: " << endl;
			for(auto data: this->lista){
				cout << data.toString() << endl;
			}
			cout << "-----------------" << endl;
		}

		void listaNElementos(int n){
			if(n > this->lista.size()){
				cout << "Número de elementos solicitados excede o tamanho da lista, mostrando todos os elementos..." << endl;
				n = this->lista.size();
			}
			cout << "As " << n << " primeiras datas da lista são: " << endl;
			for(int i = 0; i < n; i++){
				cout << (i + 1) << ". " << this->lista.at(i).toString() << endl;
			}
			cout << "-----------------" << endl;
		}

};

class ListaSalarios : public Lista {
	vector<float> lista;
	
	public:
	
	/*
	O m�todo abaixo pergunta ao usu�rios quantos
	elementos v�o existir na lista e depois
	solicita a digita��o de cada um deles
	*/	
	void entradaDeDados() {
			int qtdSalario;
			float valorSalario;

			cout << "Informe quantos salários você gostaria de inserir na lista: ";
			cin >> qtdSalario;

			for(int i = 0; i != qtdSalario; i++){
				cout << "Digite o valor do salario " << (i + 1) << ": " << endl;
				while(true){
					cin >> valorSalario;
					if(valorSalario > 0){
						lista.push_back(valorSalario);
						break;
					}
					cout << "O valor do salario deve ser maior do que zero!" << endl;
				}
			}
		sort(lista.begin(), lista.end());
		cout << "-----------------" << endl;
	}
	void mostraMediana() {

		int meio = floor(((this->lista.size() + 1) / 2.0) - 1);

		cout << "A mediana da lista de salarios é: " << endl;
		cout << this->lista.at(meio) << endl;
		cout << "-----------------" << endl;
	}
	
	void mostraMenor() {	
		cout << "O menor salario é: " << endl;
		cout << this->lista.front() << endl;
		cout << "-----------------" << endl;
	}

	void mostraMaior() {
		cout << "O maior salario é: " << endl;
		cout << this->lista.back() << endl;
		cout << "-----------------" << endl;
	}

	void listarEmOrdem(){
		cout << "Aqui esta a lista de salarios: " << endl;
		for(auto valorSalario: this->lista){
			cout << valorSalario << endl;
		}
		cout << "-----------------" << endl;
	}
	void listaNElementos(int n){
		if(n > this->lista.size()){
			cout << "Número de elementos solicitados excede o tamanho da lista, mostrando todos os elementos..." << endl;
			n = this->lista.size();
		}
		cout << "Os " << n << " primeiros salarios da lista são: " << endl;
		for(int i = 0; i < n; i++){
			cout << (i + 1) << ". " << this->lista.at(i) << endl;
		}
		cout << "-----------------" << endl;
	}
};


class ListaIdades : public Lista {
	vector<int> lista;
	
	public:
		
		/*
	O m�todo abaixo pergunta ao usu�rios quantos
	elementos v�o existir na lista e depois
	solicita a digita��o de cada um deles
	*/	
	void entradaDeDados() {
			int qtdIdades, idade;

			cout << "Informe quantas idades você gostaria de inserir na lista: ";
			cin >> qtdIdades;

			for(int i = 0; i != qtdIdades; i++){
				cout << "Digite a idade " << (i + 1) << ": " << endl;
				while(true){
					cin >> idade;
					if(idade > 0){
						lista.push_back(idade);
						break;
					}
					cout << "O valor da idade deve ser maior do que zero!" << endl;
				}
			}
		sort(lista.begin(), lista.end());
		cout << "-----------------" << endl;
	}
	void mostraMediana() {

		int meio = floor(((this->lista.size() + 1) / 2.0) - 1);

		cout << "A mediana da lista de idades é: " << endl;
		cout << this->lista.at(meio) << endl;
		cout << "-----------------" << endl;
	}
	
	void mostraMenor() {	
		cout << "A menor idade é: " << endl;
		cout << this->lista.front() << endl;
		cout << "-----------------" << endl;
	}

	void mostraMaior() {
		cout << "A maior idade é: " << endl;
		cout << this->lista.back() << endl;
		cout << "-----------------" << endl;
	}

	void listarEmOrdem(){
		cout << "Aqui esta a lista de idades: " << endl;
		for(auto idade: this->lista){
			cout << idade << endl;
		}
		cout << "-----------------" << endl;
	}
	void listaNElementos(int n){
		if(n > this->lista.size()){
			cout << "Número de elementos solicitados excede o tamanho da lista, mostrando todos os elementos..." << endl;
			n = this->lista.size();
		}
		cout << "As " << n << " primeiras idades da lista são: " << endl;
		for(int i = 0; i < n; i++){
			cout << (i + 1) << ". " << this->lista.at(i) << endl;
		}
		cout << "-----------------" << endl;
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
    

