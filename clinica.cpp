#include <iostream>
#include <sstream>
#include <string>
#include <vector>
#include <regex>

using namespace std;
class Data{
    int dia, mes, ano, hora, minuto;

    public:
        Data(int _dia, int _mes, int _ano){
            this->setData(_dia, _mes, _ano);
        }

        Data(int _dia, int _mes, int _ano, int _hora, int _minuto) {
            this->setData(_dia, _mes, _ano);
            this->setHorario(_hora, _minuto);
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

        void setHora(int _hora){
            if(horaValida(_hora, this->minuto)){
                this->hora = _hora;
            }
        }

        int getHora(){
            return this->hora;
        }

        void setMinuto(int _minuto){
            if(horaValida(this->hora, _minuto)){
                this->minuto = _minuto;
            }
        }

        int getMinuto(){
            return this->minuto;
        }

        void setData(int _dia, int _mes, int _ano){
            if(!dataValida(_dia, _mes, _ano)){
                return;
            }

            this->dia = _dia;
            this->mes = _mes;
            this->ano = _ano;
        }

        string dataToString(){
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

         void setHorario(int _hora, int _minuto){
            if(!horaValida(_hora, _minuto)){
                return;
            }

            this->hora = _hora;
            this->minuto = _minuto;
        }

        string horaToString(){
            stringstream ss;
            ss << this->hora << ":" << this->minuto;
            return ss.str();
        }

        static bool horaValida(int _hora, int _minuto){
            
            if((_hora < 0 || _hora > 23) || (_minuto > 59 || _minuto < 0)){
                cout << "Horário inválido!" << endl;
                return false;
            }

            return true;
        }

        static bool horaValida(Data * _data){
            return horaValida(_data->getHora(), _data->getMinuto());
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
            ss << "Data de Nascimento: " << this->dtNascimento->dataToString();
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
class Consulta{
    Medico *medico;
    Paciente *paciente;
    string statusConsulta , convenio;
    Data *dataHoraConsulta;
    int duracao;
    
    public:
        Consulta( Medico * _medico, Paciente * _paciente, Data * _dataHoraConsulta, int _duracao, string _convenio){
            this->setStatusConsulta("n");
            this->setDataHoraConsulta(_dataHoraConsulta);
            this->setDuracao(_duracao);
            this->setConvenio(_convenio);
            this->setMedico(_medico);
            this->setPaciente(_paciente);
        }

        void setData (int _dia, int _mes, int _ano){
            dataHoraConsulta->setData(_dia, _mes, _ano);
        }

        void setHorario (int _hora, int _minuto){
            dataHoraConsulta->setHorario(_hora, _minuto);
        }

        string toString(){
            stringstream ss;
            ss << "Status: " << this->statusConsulta << endl;
            ss << "Data: " << this->dataHoraConsulta->dataToString();
            ss << "Hora: " << this->dataHoraConsulta->horaToString();
            ss << "Duração: " << this->duracao << endl;
            ss << "Convênio: " << this->convenio << endl;
            return ss.str();
        }

        void setPaciente(Paciente * _paciente){
            this-> paciente = _paciente;
        }

        Paciente * getPaciente(){
            return paciente;
        }

        void setMedico(Medico * _medico){
            this-> medico = _medico;
        }

        Medico * getMedico(){
            return medico;
        }
        void setStatusConsulta(string _statusConsulta){
            this->statusConsulta = _statusConsulta;
        }

        string getStatusConsulta(){
            return this->statusConsulta;
        }

        void setDataHoraConsulta(Data * _dataHoraConsulta){
            if(Data::dataValida(_dataHoraConsulta)){
                this->dataHoraConsulta = _dataHoraConsulta;
            }
        }

        Data * getDataHoraConsulta(){
            return this->dataHoraConsulta;
        }

        void setDuracao(int _duracao){
            this->duracao = _duracao;
        }

        int getDuracao(){
            return this->duracao;
        }

        void setConvenio(string _convenio){

            this->convenio = _convenio;
        }

};
class ControlePacientes{
    int op;
    vector<Paciente*> pacientes;

    public:
        vector<Paciente*> getPacientes() {
            return pacientes;
        }

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
                Data * _data  = this->lerData();
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
        vector<Medico*> getMedicos() {
            return medicos;
        }

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
class ControleConsultas{
    int op;
    ControlePacientes * controlePacientes;
    ControleMedicos * controleMedicos;
    vector<Consulta*> consultas;

    public:
        ControleConsultas(ControlePacientes * _controlePacientes, ControleMedicos * _controleMedicos){
            this->controlePacientes = _controlePacientes;
            this->controleMedicos = _controleMedicos;
        }

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
                    this->criarConsulta();
                } else if(op == 2){
                    this->excluirConsulta();
                } else if(op == 3){
                    this->alterarConsulta();
                } else if(op == 4){
                    this->listarConsultas();
                } else if(op == 0){
                    return;
                } else {
                    cout << "Opção Inválida" << endl;
                }
            } while(this->op < 0 || this->op > 4);
        }

        void mostrarMenu(){
            cout << endl;
            cout << "1. Incluir Consulta" << endl;
            cout << "2. Excluir Consulta" << endl;
            cout << "3. Alterar Consulta" << endl;
            cout << "4. Listar Consultas" << endl;
            cout << "0. Sair" << endl;
            cout << "-------------------" << endl;
        }

        void alterarConsulta(){
            string _op;
            int consultaIndex = this->localizarConsulta();
            
            if(consultaIndex == -1){
                return;
            }

            Consulta * consulta = this->consultas.at(consultaIndex);

            cout << "Deseja registrar como realizada? (S/N)" << endl;
            cin >> _op;

            if(_op == "S" || _op == "s"){
                consulta->setStatusConsulta("s");
                cout << "Consulta registrada como realizada!" << endl;

                return;
            }
            
            cout << "Deseja alterar a data? (S/N)" << endl;
            cin >> _op;

            if(_op == "S" || _op == "s"){
                int _dia, _mes, _ano;

                cout << "Digite a nova data: " << endl;
                cout << "Dia: ";
                cin >> _dia;
                cout << "Mês: ";
                cin >> _mes;
                cout << "Ano: ";
                cin >> _ano;

                if(Data::dataValida(_dia, _mes, _ano)){
                    consulta->setData(_dia, _mes, _ano);
                }

                cout << "Data da consulta alterada!" << endl;
            }

            
            cout << "Deseja alterar a hora? (S/N)" << endl;
            cin >> _op;
            
            if(_op == "S" || _op == "s"){
                int _hora, _minuto;

                cout << "Digite a nova hora: " << endl;
                cout << "Hora: ";
                cin >> _hora;
                cout << "Minuto: ";
                cin >> _minuto;

                if(Data::horaValida(_hora, _minuto)){
                    consulta->setHorario(_hora, _minuto);
                }

                cout << "Hora da consulta alterada!" << endl;
            }
        }

        int localizarConsulta(){
            string _crm, _cpf;

            int medicoIndex = this->controleMedicos->localizarMedico();

            if(medicoIndex == -1){
                return -1;
            }

            Medico * medico = this->controleMedicos->getMedicos().at(medicoIndex);

            cout << "Lista de pacientes com consulta agendada com o(a) Dr(a) " << medico->getNome() << endl;
            this->listarPacientesConsultaMarcada(medico);

            int pacienteIndex = this->controlePacientes->localizarPaciente();

            if(pacienteIndex == -1){
                return -1;
            }

            Paciente * paciente = this->controlePacientes->getPacientes().at(pacienteIndex);

            int index = 0;
            for(auto consulta: this->consultas){
                if(consulta->getMedico()->getCrm() == medico->getCrm() && consulta->getPaciente()->getCpf() == paciente->getCpf()){
                    return index;
                }
                index++;
            }
            cout << "Consulta não encontrada!" << endl;

            return -1;
        }

        void listarPacientesConsultaMarcada(Medico * _medico){
            for(auto consulta: consultas){
                if(_medico->getCrm()==consulta->getMedico()->getCrm()){
                    cout << consulta->getPaciente()->getCpf() << " - " << consulta->getPaciente()->getNome() << endl;
                }
            }
        }
        void excluirConsulta(){
            int index = this->localizarConsulta();
            if(index == -1){
                return;
            }
            consultas.erase(this->consultas.begin()+index);
            cout << "Consulta excluida com sucesso!" << endl;
        } 
        void listarConsultas(){
            cout << "Lista de consultas: " << endl;
            for(auto consulta : this->consultas){
                cout << "--------------------- " << endl;
                cout << consulta->toString();  
            }
        }
        void criarConsulta(){
            int indexP, indexM, dia, mes, ano, hora, minuto, duracao;
            string crm, cpf, convenio; 
            Medico * medico;
            Paciente * paciente;

            indexM = this->controleMedicos->localizarMedico();
            if(indexM == -1){
                return;
            }
            medico = this->controleMedicos->getMedicos().at(indexM);

            indexP = this->controlePacientes->localizarPaciente();
            if(indexP == -1){
                return;
            }
            paciente = this->controlePacientes->getPacientes().at(indexP);

            cout << "Digite a nova data: " << endl;
            cout << "Dia: ";
            cin >> dia;
            cout << "Mês: ";
            cin >> mes;
            cout << "Ano: ";
            cin >> ano;

            if(!Data::dataValida(dia, mes, ano)){
                return;
            }
            cout << "Digite a nova hora: " << endl;
            cout << "Hora: ";
            cin >> hora;
            cout << "Minuto: ";
            cin >> minuto;

            if(!Data::horaValida(hora, minuto)){
                return;
            }
            cout << "Escreva a duração da consulta: " << endl;
            cin >> duracao;
            cout << "Escreva o convenio da consulta: " << endl;
            cin >> convenio;
            
            Data * data = new Data(dia, mes, ano, hora, minuto);
            Consulta * consulta = new Consulta(medico, paciente, data, duracao, convenio);
            this->consultas.push_back(consulta);  
             
        }
};
class App{
    int op;
    ControlePacientes * controlePacientes = new ControlePacientes();
    ControleMedicos * controleMedicos = new ControleMedicos();
    ControleConsultas * controleConsultas = new ControleConsultas(controlePacientes, controleMedicos);

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
                    this->controleConsultas->run();
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
            cout << "3. Gestão de Consultas" << endl;
            cout << "0. Sair" << endl;
            cout << "-------------------" << endl;
        }
};

int main(){
    App * app = new App();

    app->run();

    return 0;
}