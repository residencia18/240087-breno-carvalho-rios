#include <iostream>
#include <sstream>
#include <string>
#include <vector>
#include <regex>

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

        static bool dataValida(int _dia, int _mes, int _ano){
            int maxDias = 31;

            if((_mes < 1 || _mes > 12) || (_ano < 1900)){
                cout << "Data inválida!" << endl;
                return false;
            }

            if(_mes == 2){
                maxDias = 28;
                if(_ano % 4 == 0){
                    maxDias = 29;
                }
            }

            if(_mes == 4 || _mes == 6 || _mes == 9 || _mes == 11){
                maxDias = 30;
            }

            if(_dia < 1 || _dia > maxDias){
                cout << "Data inválida!" << endl;
                return false;
            }

            return true;
        }

        static bool dataValida(Data * _data){
            return dataValida(_data->getDia(), _data->getMes(), _data->getAno());
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
            ss << "CPF: " << this->cpf << endl;
            ss << "Nome: " << this->nome << endl;
            ss << "Data de Nascimento: " << this->dtNascimento->toString();
            return ss.str();
        }

        void setCpf(string _cpf){
            if(Paciente::cpfValido(_cpf)){
                this->cpf = _cpf;
            }
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
            if(Data::dataValida(_dtNascimento)){
                this->dtNascimento = _dtNascimento;
            }
        }

        Data * getDtNascimento(){
            return this->dtNascimento;
        }

        static bool cpfValido(string _cpf){
            return regex_match(_cpf, regex("[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}"));
        }
};
class Medico{
    string crm, nome, especialidade;

    public:
        Medico(string _crm, string _nome, string _especialidade){
            this->setCrm(_crm);
            this->setNome(_nome);
            this->setEspecialidade(_especialidade);
        }

        string toString(){
            stringstream ss;
            ss << "CRM: " << this->crm << endl;
            ss << "Nome: " << this->nome << endl;
            ss << "Especialidade: " << this->especialidade;
            return ss.str();
        }

        void setCrm(string _crm){
            if(Medico::crmValido(_crm)){
                this->crm = _crm;
            }
        }

        string getCrm(){
            return this->crm;
        }

        void setNome(string _nome){
            this->nome = _nome;
        }

        string getNome(){
            return this->nome;
        }

        void setEspecialidade(string _especialidade){
            this->especialidade = _especialidade;
        }

        string getEspecialidade(){
            return this->especialidade;
        }

        static bool crmValido(string _crm){
            return _crm.size() == 6;
        }
};
class ControlePacientes{
    int op;
    vector<Paciente*> pacientes;

    public:
        void run(){
            op = -1;
            while(this->op != 0){
                lerOpcao();
            }
        }

        void lerOpcao(){
            do{
                mostrarMenu();
                cout << "Digite uma opção: ";
                cin >> this->op;

                if(op == 1){
                    this->criarPaciente();
                } else if(op == 2){
                    this->excluirPaciente();
                } else if(op == 3){
                    this->alterarPaciente();
                } else if(op == 4){
                    this->imiprimirListaPacientes();
                } else if(op == 5){
                    this->imiprimirDadosPaciente();
                } else if(op == 0){
                    return;
                } else {
                    cout << "Opção Inválida" << endl;
                }
            } while(this->op < 0 || this->op > 5);
        }

        Data * lerData(){
            while(true){
                int _dia, _mes, _ano;
                cout << "Dia: ";
                cin >> _dia;
                cout << "Mes: ";
                cin >> _mes;
                cout << "Ano: ";
                cin >> _ano;

                if(Data::dataValida(_dia, _mes, _ano)){
                    return new Data(_dia, _mes, _ano);
                }
            }
        }

        string lerCpf(){
            string _cpf;
            while(true){
                cout << "Digite o CPF do paciente (XXX.XXX.XXX-XX): " << endl;
                getline(cin >> ws, _cpf);

                if(!Paciente::cpfValido(_cpf)){
                    cout << "CPF inválido!" << endl;
                } else if(pacienteJaExiste(_cpf)){
                    cout << "CPF já cadastrado!" << endl;
                } else{
                    return _cpf;
                }
            }
        }

        void mostrarMenu(){
            cout << endl;
            cout << "1. Incluir Paciente" << endl;
            cout << "2. Excluir Paciente (por CPF)" << endl;
            cout << "3. Alterar Paciente (por CPF)" << endl;
            cout << "4. Listar Pacientes" << endl;
            cout << "5. Localizar Paciente (por CPF)" << endl;
            cout << "0. Sair" << endl;
            cout << "-------------------" << endl;
        }

        void criarPaciente(){
            string _cpf, _nome;
            Data * _data;

            _cpf = this->lerCpf();

            cout << "Digite o nome do paciente: " << endl;
            getline(cin >> ws, _nome);

            cout << "Digite a data de nascimento: " << endl;
            _data = this->lerData();

            Paciente * novoPaciente = new Paciente(_cpf, _nome, _data);

            pacientes.push_back(novoPaciente);
        }

        void excluirPaciente(){
            int index = this->localizarPaciente();
            if(index == -1){
                return;
            }

            this->pacientes.erase(this->pacientes.begin() + index);
            cout << "Paciente excluído!" << endl;
        }

        void alterarPaciente(){
            string _cpf, _nome, _op;
            int index = this->localizarPaciente();

            if(index == -1){
                return;
            }

            Paciente * paciente = this->pacientes.at(index);
            cout << "-------------------" << endl;
            cout << "Dados de " << paciente->getNome() << endl;
            cout << paciente->toString() << endl;
            cout << "-------------------" << endl;
            
            cout << "Deseja alterar o nome? (S/N)" << endl;
            cin >> _op;
            if(_op == "S" || _op == "s"){
                cout << "Digite o novo nome: " << endl;
                getline(cin >> ws, _nome);
                paciente->setNome(_nome);
                cout << "Nome alterado!" << endl;
            }
            
            cout << "Deseja alterar a data de nascimento? (S/N)" << endl;
            cin >> _op;
            if(_op == "S" || _op == "s"){
                cout << "Digite a nova data de nascimento: " << endl;
                Data * _data  = lerData();
                paciente->setDtNascimento(_data);
                cout << "Data de nascimento alterada!" << endl;
            }
        }

        void imiprimirListaPacientes(){
            cout << "Lista de Pacientes" << endl;
            for(auto paciente: this->pacientes) {
                cout << "-------------------" << endl;
                cout << paciente->toString() << endl;
            }
        }

        void imiprimirDadosPaciente(){
            int pacienteIndex = this->localizarPaciente();

            if(pacienteIndex == -1){
                return;
            }

            Paciente * paciente = this->pacientes.at(pacienteIndex);
            cout << "-------------------" << endl;
            cout << "Dados de " << paciente->getNome() << endl;
            cout << paciente->toString() << endl;
        }

        int localizarPaciente(){
            string _cpf;
            cout << "Digite o CPF do paciente:" << endl;
            getline(cin >> ws, _cpf);

            int index = 0;
            for(auto paciente: this->pacientes){
                if(paciente->getCpf() == _cpf){
                    return index;
                }
                index++;
            }
            cout << "Paciente não encontrado!" << endl;

            return -1;
        }

        int pacienteJaExiste(string _cpf){
            for(auto paciente: this->pacientes){
                if(paciente->getCpf() == _cpf){
                    return true;
                }
            }

            return false;
        }
};
class ControleMedicos{
    int op;
    vector<Medico*> medicos;

    public:
        void run(){
            op = -1;
            while(this->op != 0){
                lerOpcao();
            }
        }

        void lerOpcao(){
            do{
                mostrarMenu();
                cout << "Digite uma opção: ";
                cin >> this->op;

                if(op == 1){
                    this->criarMedico();
                } else if(op == 2){
                    this->excluirMedico();
                } else if(op == 3){
                    this->alterarMedico();
                } else if(op == 4){
                    this->imiprimirListaMedicos();
                } else if(op == 5){
                    this->imiprimirDadosMedico();
                } else if(op == 0){
                    return;
                } else {
                    cout << "Opção Inválida" << endl;
                }
            } while(this->op < 0 || this->op > 5);
        }

        string lerCrm(){
            string _crm;
            while(true){
                cout << "Digite o CRM do médico (6 dígitos): " << endl;
                getline(cin >> ws, _crm);

                if(!Medico::crmValido(_crm)){
                    cout << "CRM inválido!" << endl;
                } else if(medicoJaExiste(_crm)){
                    cout << "CRM já cadastrado!" << endl;
                } else{
                    return _crm;
                }
            }
        }

        void mostrarMenu(){
            cout << endl;
            cout << "1. Incluir Médico" << endl;
            cout << "2. Excluir Médico (por CRM)" << endl;
            cout << "3. Alterar Médico (por CRM)" << endl;
            cout << "4. Listar Médicos" << endl;
            cout << "5. Localizar Médico (por CRM)" << endl;
            cout << "0. Sair" << endl;
            cout << "-------------------" << endl;
        }

        void criarMedico(){
            string _crm, _nome, _especialidade;

            _crm = this->lerCrm();

            cout << "Digite o nome do médico: " << endl;
            getline(cin >> ws, _nome);

            cout << "Digite a especialidade do médico: " << endl;
            getline(cin >> ws, _especialidade);

            Medico * novoMedico = new Medico(_crm, _nome, _especialidade);

            medicos.push_back(novoMedico);
        }

        void excluirMedico(){
            int index = this->localizarMedico();
            if(index == -1){
                return;
            }

            this->medicos.erase(this->medicos.begin() + index);
            cout << "Médico excluído!" << endl;
        }

        void alterarMedico(){
            string _crm, _nome, _especialidade, _op;
            int index = this->localizarMedico();

            if(index == -1){
                return;
            }

            Medico * medico = this->medicos.at(index);
            cout << "-------------------" << endl;
            cout << "Dados de " << medico->getNome() << endl;
            cout << medico->toString() << endl;
            cout << "-------------------" << endl;
            
            cout << "Deseja alterar o nome? (S/N)" << endl;
            cin >> _op;
            if(_op == "S" || _op == "s"){
                cout << "Digite o novo nome: " << endl;
                getline(cin >> ws, _nome);
                medico->setNome(_nome);
                cout << "Nome alterado!" << endl;
            }
            
            cout << "Deseja alterar a especialidade? (S/N)" << endl;
            cin >> _op;
            if(_op == "S" || _op == "s"){
                cout << "Digite a nova especialidade: " << endl;
                getline(cin >> ws, _especialidade);
                medico->setEspecialidade(_especialidade);
                cout << "Especialidade alterada!" << endl;
            }
        }

        void imiprimirListaMedicos(){
            cout << "Lista de Medicos" << endl;
            for(auto medico: this->medicos) {
                cout << "-------------------" << endl;
                cout << medico->toString() << endl;
            }
        }

        void imiprimirDadosMedico(){
            int medicoIndex = this->localizarMedico();

            if(medicoIndex == -1){
                return;
            }

            Medico * medico = this->medicos.at(medicoIndex);
            cout << "-------------------" << endl;
            cout << "Dados do(a) Doutor(a) " << medico->getNome() << endl;
            cout << medico->toString() << endl;
        }

        int localizarMedico(){
            string _crm;
            cout << "Digite o CRM do médico:" << endl;
            getline(cin >> ws, _crm);

            int index = 0;
            for(auto medico: this->medicos){
                if(medico->getCrm() == _crm){
                    return index;
                }
                index++;
            }
            cout << "Médico não encontrado!" << endl;

            return -1;
        }

        int medicoJaExiste(string _crm){
            for(auto medico: this->medicos){
                if(medico->getCrm() == _crm){
                    return true;
                }
            }

            return false;
        }
};
class App{
    int op;
    ControlePacientes * controlePacientes = new ControlePacientes();
    ControleMedicos * controleMedicos = new ControleMedicos();

    public:
        void run(){
            op = -1;
            while(this->op != 0){
                lerOpcao();
            }
        }

        void lerOpcao(){
            do{
                mostrarMenu();
                cout << "Digite uma opção: ";
                cin >> this->op;

                if(op == 1){
                    this->controlePacientes->run();
                } else if(op == 2){
                    this->controleMedicos->run();
                } else if(op == 3){
                    // ToDo
                } else if(op == 0){
                    return;
                } else {
                    cout << "Opção Inválida" << endl;
                }
            } while(this->op < 0 || this->op > 3);
        }

        void mostrarMenu(){
            cout << endl;
            cout << "1. Gestão de Pacientes" << endl;
            cout << "2. Gestão de Médicos" << endl;
            cout << "0. Sair" << endl;
            cout << "-------------------" << endl;
        }
};

int main(){
    App * app = new App();

    app->run();

    return 0;
}