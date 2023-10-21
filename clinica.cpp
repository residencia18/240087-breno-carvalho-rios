#include <iostream>
#include <sstream>
#include <string>
#include <vector>

using namespace std;
class Data{
    int dia, mes, ano;

    public:
        Data(int _dia, int _mes, int _ano){
            this->setData(_dia, _mes, _ano);
        }

        void setDia(int _dia){
            if(dataValida(_dia, this->mes, this->ano)){
                this->dia = _dia;
            }
        }

        int getDia(){
            return this->dia;
        }

        void setMes(int _mes){
            if(dataValida(this->dia, _mes, this->ano)){
                this->mes = _mes;
            }
        }

        int getMes(){
            return this->mes;
        }

        void setAno(int _ano){
            if(dataValida(this->dia, this->mes, _ano)){
                this->ano = _ano;
            }
        }

        int getAno(){
            return this->ano;
        }

        void setData(int _dia, int _mes, int _ano){
            if(!dataValida(_dia, _mes, _ano)){
                cout << "Data inválida!" << endl;
                return;
            }

            this->dia = _dia;
            this->mes = _mes;
            this->ano = _ano;
        }

        string toString(){
            stringstream ss;
            ss << this->dia << "/" << this->mes << "/" << this->ano;
            return ss.str();
        }

        bool dataValida(int _dia, int _mes, int _ano){
            int maxDias = 31;

            if((_mes < 1 || _mes > 12) || (_ano < 1900)){
                return false;
            }

            if(_mes == 2){
                maxDias = 28;
                if(ano % 4 == 0){
                    maxDias = 29;
                }
            }

            if(_mes == 4 || _mes == 6 || _mes == 9 || _mes == 11){
                maxDias = 30;
            }

            if(_dia < 1 || _dia > maxDias){
                return false;
            }

            return true;
        }
};

class Paciente{
    string cpf, nome;
    Data * dtNascimento;

    public:
        Paciente(string _cpf, string _nome, Data * _dtNascimento){
            this->setNome(_nome);
            this->setCpf(_cpf);
            this->setDtNascimento(_dtNascimento);
        }

        string toString(){
            stringstream ss;
            ss << "Cpf: " << this->cpf << endl;
            ss << "Nome: " << this->nome << endl;
            ss << "Data de Nascimento: " << this->dtNascimento->toString() << endl;
            return ss.str();
        }

        void setCpf(string _cpf){
            // fazer validacoes
            this->cpf = _cpf;
        }

        string getCpf(){
            return this->cpf;
        }

        void setNome(string _nome){
            this->nome = _nome;
        }

        string getNome(){
            return this->nome;
        }

        void setDtNascimento(Data * _dtNascimento){
            this->dtNascimento = _dtNascimento;
        }

        Data * getDtNascimento(){
            return this->dtNascimento;
        }
};

class Medico{
    string crm, nome, especialidade;
};

class App{
    int op = -1;
    vector<Paciente*> pacientes;

    public:
        void run(){
            while(this->op != 0){
                lerOpcao();
            }
        }

        void lerOpcao(){
            do{
                mostrarMenu();
                cout << "Digite uma opção: ";
                cin >> this->op;
            } while(this->op < 0 || this->op > 5);
        }

        void mostrarMenu(){
            cout << endl;
            cout << "1. Incluir Paciente" << endl;
            cout << "2. Excluir Paciente" << endl;
            cout << "3. Alterar Paciente" << endl;
            cout << "4. Listar Pacientes" << endl;
            cout << "5. Localizar Paciente (por CPF)" << endl;
            cout << "0. Sair" << endl;
        }

        void criarPaciente(){
            int _dia, _mes, _ano;
            string _cpf, _nome;
            Data * _data;

            cout << "Digite o cpf do paciente: " << endl;
            getline(cin >> ws, _cpf);

            cout << "Digite o nome do paciente: " << endl;
            getline(cin >> ws, _nome);

            cout << "Digite a data de nascimento: " << endl;
            cin >> _dia >> _mes >> _ano;
            _data = new Data(_dia, _mes, _ano);

            Paciente * novoPaciente = new Paciente(_cpf, _nome, _data);

            pacientes.push_back(novoPaciente);
        }

        void imiprimirListaPacientes(){
            cout << "Lista de Pacientes" << endl;
            for (auto paciente: this->pacientes) {
                cout << "-------------------" << endl;
                cout << paciente->toString() << endl;
            }
        }
};

int main(){
    App * app = new App();

    app->run();

    return 0;
}