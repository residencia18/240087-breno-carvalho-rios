#include <iostream>

using namespace std;
class Data{
    int dia, mes, ano;

    public:
    Data(int _dia, int _mes, int _ano){
        this->setData(_dia, _mes, _ano);
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
        if(!dataValida){
            cout << "Data inválida!" << endl;
            return;
        }

        this->dia = _dia;
        this->mes = _mes;
        this->ano = _ano;
    }

    Data * getData(){
        return this;
    }
};

class Paciente{
    string cpf, nome;
    Data * dtNascimento;

    public:
        Paciente(string _nome, string _cpf, Data * _dtNascimento){
            this->setNome(_nome);
            this->setCpf(_cpf);
            this->setDtNascimento(_dtNascimento);
        }

        void setCpf(string _cpf){
            // fazer validacoes
            this->cpf = _cpf;
        }

        string getCpf(){
            return this->cpf;
        }

        void setNome(string _nome){
            this->nome = nome;
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

int main(){
    
    return 0;
}