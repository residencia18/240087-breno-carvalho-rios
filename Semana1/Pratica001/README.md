# Atividade Prática 001

# O que é uma classe em Java e qual é a diferença entre uma classe e um objeto? Dê 5 exemplos mostrando-os em C++ e em Java.

Uma classe é um tipo de dado que atua como "modelo" de um objeto, ela contém os atributos que o definem, bem como seus métodos.

As classes são a base da programação orientada a objetos e em java não é diferente. Podemos usar classes para representar qualquer entidade do mundo real, por exemplo: Animal, Carro, Pessoa etc.
Se considerarmos a classe carro como exemplo poderíamos ter:

### Atributos de Carro:

* Marca
* Modelo
* Aceleração
* Portas

### Métodos de Carro:

* Acelerar
* Frear

Um objeto por sua vez é esse "modelo" preenchido, ou seja, uma classe após seus atributos terem sido preenchidos. Por exemplo usando a nossa classe Carro de antes poderíamos ter o objeto ferrari:

### Atributos de Ferrari:

* Marca: Ferrari
* Modelo: 296 GTB
* Aceleração: 2.9 seg
* Portas: 2

## Agora alguns exemplos:

## Em C++

### Classe Carro

``` c
class Carro {
    string marca, modelo;
    float aceleracao;
    int portas;

    public:
    Carro(string _marca, string _modelo, float _aceleracao, int _portas){
        this->marca = _marca;
        this->modelo = _modelo;
        this->aceleracao _aceleracao;
        this->portas = _portas;
    }

    void acelerar(){
        cout << "Carro acelerando, chegando em 100km/h em " + aceleracao + " segundos.";
    }

    void frear(){
        cout << "Carro freando";
    }
};
```

### Classe Data

``` c
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
```

### Classe Paciente

``` c
class Paciente{
    string cpf, nome;
    Data * dtNascimento; // Exemplo de classe Data acima

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
```

### Classe Médico

``` c
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
```

``` c
class Cachorro {
    string nome;
    string raca;
    int idade;
    bool castrado;

    public:
    Cachorro(string nome, string raca, int idade, bool castrado) {
        this->nome = nome;
        this->raca = raca;
        this->idade = idade;
        this->castrado = castrado;
    }

    string getNome() {
        return nome;
    }

    void setNome(string nome) {
        this->nome = nome;
    }

    string getRaca() {
        return raca;
    }

    void setRaca(string raca) {
        this->raca = raca;
    }

    int getIdade() {
        return idade;
    }

    void setIdade(int idade) {
        this->idade = idade;
    }

    bool isCastrado() {
        return castrado;
    }

    void setCastrado(bool castrado) {
        this->castrado = castrado;
    }

    void latir() {
        cout << "Au au!" << endl;
    }

    void pular() {
        cout << "Pulo!" << endl;
    }

    void correr() {
        cout << "Corre!" << endl;
    }

    string toString() {
        stringstream ss;
        ss << "Nome: " << this->nome << endl;
        ss << "Raça: " << this->raca << endl;
        ss << "Idade: " << this->idade << endl;
        ss << "Castrado: " << this->castrado;
        return ss.str();
    }
}
```

## Em Java

### Classe Carro

``` java
public class Carro {  
    private String marca;
    private String modelo;
    private float aceleracao;
    private int portas;

    public Carro(String marca, String modelo, float aceleracao, int portas) {
        this.marca = marca;
        this.modelo = modelo;
        this.aceleracao = aceleracao;
        this.portas = portas;
    }

    public void acelerar() {
        System.out.println("Carro acelerando, chegando em 100km/h em " + aceleracao + " segundos.");
    }

    public void frear() {
        System.out.println("Carro freando");
    }
}
```

### Classe Data

``` Java
public class Data {
    private int dia;
    private int mes;
    private int ano;

    public Data(int dia, int mes, int ano) {
        if (!dataValida(dia, mes, ano)) {
            throw new IllegalArgumentException("Data Inválida");
        }
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }

    public void setDia(int dia) {
        if (dataValida(dia, this.mes, this.ano)) {
            this.dia = dia;
        } else {
            throw new IllegalArgumentException("Dia inválido");
        }
    }

    public int getDia() {
        return this.dia;
    }

    public void setMes(int mes) {
        if (dataValida(this.dia, mes, this.ano)) {
            this.mes = mes;
        } else {
            throw new IllegalArgumentException("Mês inválido");
        }
    }

    public int getMes() {
        return this.mes;
    }

    public void setAno(int ano) {
        if (dataValida(this.dia, this.mes, ano)) {
            this.ano = ano;
        } else {
            throw new IllegalArgumentException("Mês inválido");
        }
    }

    public int getAno() {
        return this.ano;
    }

    public static boolean dataValida(int dia, int mes, int ano) {
        if (mes < 1 || mes > 12 || ano < 1900) {
            return false;
        }

        int maxDias = 31;

        if (mes == 2) {
            maxDias = 28;
            if (ano % 4 == 0) {
                maxDias = 29;
            }
        } else if (mes == 4 || mes == 6 || mes == 9 || mes == 11) {
            maxDias = 30;
        }

        return dia >= 1 && dia <= maxDias;
    }

    @Override
    public String toString() {
        return this.dia + "/" + this.mes + "/" + this.ano;
    }
}
```

### Classe Paciente

``` Java
public class Paciente {
    private String cpf;
    private String nome;
    private Data dtNascimento;

    public Paciente(String cpf, String nome, Data dtNascimento) {
        if (!Paciente.cpfValido(cpf)) {
            throw new IllegalArgumentException("CPF Inválido");
        }
        this.cpf = cpf;
        this.nome = nome;
        this.dtNascimento = dtNascimento;
    }

    public void setCpf(String cpf) {
        if (Paciente.cpfValido(cpf)) {
            this.cpf = cpf;
        } else {
            throw new IllegalArgumentException("CPF Inválido");
        }
    }

    public String getCpf() {
        return this.cpf;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getNome() {
        return this.nome;
    }

    public void setDtNascimento(Data dtNascimento) {
        this.dtNascimento = dtNascimento;
    }

    public Data getDtNascimento() {
        return this.dtNascimento;
    }

    public static boolean cpfValido(String cpf) {
        return cpf.matches("[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}");
    }

    @Override
    public String toString() {
        return "CPF: " + this.cpf + "\n" +
                "Nome: " + this.nome + "\n" +
                "Data de Nascimento: " + this.dtNascimento.toString();
    }
}
```

``` Java
public class Medico {
    private String crm;
    private String nome;
    private String especialidade;

    public Medico(String crm, String nome, String especialidade) {
        if (!Medico.crmValido(crm)) {
            throw new IllegalArgumentException("CRM Válido");
        }
        this.crm = crm;
        this.nome = nome;
        this.especialidade = especialidade;
    }

    public void setCrm(String crm) {
        if (Medico.crmValido(crm)) {
            this.crm = crm;
        } else {
            throw new IllegalArgumentException("CRM Válido");
        }
    }

    public String getCrm() {
        return this.crm;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getNome() {
        return this.nome;
    }

    public void setEspecialidade(String especialidade) {
        this.especialidade = especialidade;
    }

    public String getEspecialidade() {
        return this.especialidade;
    }

    public static boolean crmValido(String crm) {
        return crm.length() == 6;
    }

    @Override
    public String toString() {
        return "CRM: " + this.crm + "\n" +
                "Nome: " + this.nome + "\n" +
                "Especialidade: " + this.especialidade;
    }
}
```

``` Java
public class Cachorro {
    private String nome;
    private String raça;
    private int idade;
    private boolean castrado;

    public Cachorro(String nome, String raça, int idade, boolean castrado) {
        this.nome = nome;
        this.raça = raça;
        this.idade = idade;
        this.castrado = castrado;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getRaça() {
        return raça;
    }

    public void setRaça(String raça) {
        this.raça = raça;
    }

    public int getIdade() {
        return idade;
    }

    public void setIdade(int idade) {
        this.idade = idade;
    }

    public boolean isCastrado() {
        return castrado;
    }

    public void setCastrado(boolean castrado) {
        this.castrado = castrado;
    }

    public void latir() {
        System.out.println("Au au!");
    }

    public void pular() {
        System.out.println("Pulo!");
    }

    public void correr() {
        System.out.println("Corre!");
    }

    @Override
    public String toString() {
        return "Nome: " + nome + "\nRaça: " + raça + "\nIdade: " + idade + "\nCastrado: " + castrado;
    }
}
```