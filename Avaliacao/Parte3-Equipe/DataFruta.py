from abc import ABC, abstractmethod
import os
import re

class Data:
    
    def __init__(self, dia = 1, mes = 1, ano = 2000):
        if dia < 1 or dia > 31:
            raise ValueError("Dia inválido")
        if mes < 1 or mes > 12:
            raise ValueError("Mês inválido")
        if ano < 2000 or ano > 2100:
            raise ValueError("Ano inválido")
        self.__dia = dia
        self.__mes = mes
        self.__ano = ano

    @property
    def dia(self):
        return self.__dia
    
    @dia.setter
    def dia(self, dia):
        if dia < 1 or dia > 31:
            raise ValueError("Dia inválido")
        self.__dia = dia

    @property
    def mes(self):
        return self.__mes
    
    @mes.setter
    def mes(self, mes):
        if mes < 1 or mes > 12:
            raise ValueError("Mês inválido")
        self.__mes = mes

    @property
    def ano(self):
        return self.__ano
    
    @ano.setter
    def ano(self, ano):
        if ano < 2000 or ano > 2100:
            raise ValueError("Ano inválido")
        self.__ano = ano
    
    def __str__(self):
        return "{}/{}/{}".format(self.__dia, self.__mes, self.__ano)

    def __eq__(self, outraData):
        return  self.__dia == outraData.__dia and \
                self.__mes == outraData.__mes and \
                self.__ano == outraData.__ano
    
    def __lt__(self, outraData):
        if self.__ano < outraData.__ano:
            return True
        elif self.__ano == outraData.__ano:
            if self.__mes < outraData.__mes:
                return True
            elif self.__mes == outraData.__mes:
                if self.__dia < outraData.__dia:
                    return True
        return False
    
    def __gt__(self, outraData):
        if self.__ano > outraData.__ano:
            return True
        elif self.__ano == outraData.__ano:
            if self.__mes > outraData.__mes:
                return True
            elif self.__mes == outraData.__mes:
                if self.__dia > outraData.__dia:
                    return True
        return False
	
	
    def __init__ (self, _dia, _mes, _ano):
        self.dia = _dia
        self.mes = _mes
        self.ano = _ano
    
    def toString(self):
        ret = ""
        ret.append(str(self.__dia))
        ret.append("/")
        ret.append(str(self.__mes))
        ret.append("/")
        ret.append(str(self.__ano))
        return ret

class AnaliseDados(ABC): 

    @abstractmethod
    def __init__(self, tipoDeDados):
        self.__tipoDeDados = tipoDeDados

    @abstractmethod
    def entradaDeDados(self):
        pass

    @abstractmethod
    def mostraMediana(self):
        pass
    
    @abstractmethod
    def mostraMenor(self):
        pass

    @abstractmethod
    def mostraMaior(self):
        pass

class ListaNomes(AnaliseDados):
    
    def __init__(self):
        super().__init__(type("String"))
        self.__lista = []        

    def entradaDeDados(self):
        '''
        Este método solicita a digitação de um
        nome e o adiciona na lista de nomes.
        '''

        nome = input(f"Digite o nome: ")

        if len(nome.strip()) <= 0:
            print("O nome não pode estar em branco!")
            return
        
        self.__lista.append(nome)
        print("Nome adicionado!")
		

    def mostraMediana(self):
        '''
        Este método ordena a lista e mostra o
        elemento que está na metade da lista
        '''
        if len(self.__lista) <= 0:
            return

        meio = (((len(self.__lista) + 1) // 2) - 1)
        self.__lista.sort()

        print("A mediana da lista de nomes é: ", self.__lista[meio])

    def mostraMenor(self):
        '''
        Este método retorna o menos elemento da lista
        '''
        if len(self.__lista) <= 0:
            return

        print("O primeiro nome em ordem alfabética é: ", min(self.__lista))

    def mostraMaior(self):
        '''
        Este método retorna o maior elemento da lista
        '''
        if len(self.__lista) <= 0:
            return

        print("O último nome em ordem alfabética é: ", max(self.__lista))

    def __str__(self):
        return '\n'.join(self.__lista)
    
    def listaDados(self):
        for index, nome in enumerate(self.__lista):
            print(f"{index + 1}. {nome}")
    
    def menu(self):
        while(True):
            os.system('cls' if os.name == 'nt' else 'clear')
            print("========== Menu ==========")
            print("[1] Incluir um nome")
            print("[2] Listar nomes")
            print("[0] Voltar")
            print()

            op = input("Digite uma opção -> ")
            try:
                op = int(op)
            except:
                print("Digite uma opção válida!")
                return
            
            match op:
                case 1:
                    self.entradaDeDados()
                case 2:
                    self.listaDados()
                case 0:
                    pass
                case _:
                    print("Opção Inválida")
            
            if(op == 0):
                return

            input("Pressione uma tecla para continuar...")
	
class ListaDatas(AnaliseDados):
        
    def __init__(self):
        super().__init__(type(Data))
        self.__lista = []        
    
    def entradaDeDados(self):
        '''
        Este método solicita a digitação de uma
        data e o adiciona na lista de datas.
        '''

        data = input(f"Digite a data (dd/mm/yyyy): ")

        if len(data.strip()) <= 0:
            print("A data não pode estar em branco!")
            return
        
        if not re.search("[0-9]{2}/[0-9]{2}/[0-9]{4}", data):
            print("Formato Inválido!")
            return

        data = data.split('/')

        try:
            data = Data(int(data[0]), int(data[1]), int(data[2]))
        except ValueError as ex:
            print(ex)
            return
        
        self.__lista.append(data)
        print("Data adicionada!")
    
    def mostraMediana(self):
        '''
        Este método ordena a lista e mostra o
        elemento que está na metade da lista
        '''

        if len(self.__lista) <= 0:
            return

        meio = (((len(self.__lista) + 1) // 2) - 1)
        self.__lista.sort()

        print("A mediana da lista de datas é: ", self.__lista[meio])
     
    def mostraMenor(self):
        '''
        Este método retorna o menos elemento da lista
        '''

        print("A menor data é: ", min(self.__lista))
    
    def mostraMaior(self):
        '''
        Este método retorna o maior elemento da lista
        '''

        print("A maior data é: ", max(self.__lista))
    
    def __str__(self):
        return '\n'.join(self.__lista)
    
    def listaDados(self):
        for index, data in enumerate(self.__lista):
            print(f"{index + 1}. {data}")

    def alteraDataAntes2019(self):
        dia = input(f"Digite o novo dia das datas anteriores a 2019: ")
        try:
            dia = int(dia)
        except ValueError as e:
            print(e)
            return
        except:
            print("Digite um valor válido!")
            return
        
        for data in self.__lista:
            if(data.ano < 2019):
                data.dia = dia
        
        self.listaDados()

    def menu(self):
        while(True):
            os.system('cls' if os.name == 'nt' else 'clear')
            print("========== Menu ==========")
            print("[1] Incluir uma data")
            print("[2] Listar datas")
            print("[3] Modificar o dia das datas anteriores a 2019")
            print("[0] Voltar")
            print()

            op = input("Digite uma opção -> ")
            try:
                op = int(op)
            except:
                print("Digite uma opção válida!")
                return
            
            match op:
                case 1:
                    self.entradaDeDados()
                case 2:
                    self.listaDados()
                case 3:
                    self.alteraDataAntes2019()
                case 0:
                    pass
                case _:
                    print("Opção Inválida")
        
            if(op == 0):
                    return

            input("Pressione uma tecla para continuar...")
    
class ListaSalarios(AnaliseDados):

    def __init__(self):
        super().__init__(type(float))
        self.__lista = []        

    def entradaDeDados(self):
        '''
        Este método solicita a digitação de um
        salario e o adiciona na lista de salarios.
        '''
        
        salario = input(f"Digite o valor do salario: ")
        try:
            salario = int(salario)
        except:
            print("Digite um valor válido!")
            return

        if salario <= 0:
            print("O salário deve ser positivo!")
            return
        
        self.__lista.append(salario)
        print("Salário adicionado!")

    def mostraMediana(self):
        '''
        Este método ordena a lista e mostra o
        elemento que está na metade da lista
        '''
        if len(self.__lista) <= 0:
            return

        meio = (((len(self.__lista) + 1) // 2) - 1)
        self.__lista.sort()

        mediana = self.__lista[meio]

        if len(self.__lista) % 2 == 0:
            mediana = (self.__lista[meio] + self.__lista[meio + 1]) / 2

        print("A mediana da lista de salários é: ", mediana)

    def mostraMenor(self):
        '''
        Este método retorna o menos elemento da lista
        '''
        if len(self.__lista) <= 0:
            return

        print("O menor salário é: ", min(self.__lista))

    def mostraMaior(self):
        '''
        Este método retorna o maior elemento da lista
        '''
        if len(self.__lista) <= 0:
            return

        print("O maior salário é: ", max(self.__lista))
    
    def __str__(self):
        return '\n'.join(self.__lista)

    def listaDados(self):
        for index, salario in enumerate(self.__lista):
            print(f"{index + 1}. {salario}")
        
    def folhaReajustada(self):
        for index, salario in enumerate(self.__lista):
            print(f"{index + 1}. {salario * 1.1}")

    def menu(self):
        while(True):
            os.system('cls' if os.name == 'nt' else 'clear')
            print("========== Menu ==========")
            print("[1] Incluir um salário")
            print("[2] Listar salários")
            print("[3] Folha com reajuste de 10%")
            print("[0] Voltar")
            print()

            op = input("Digite uma opção -> ")
            try:
                op = int(op)
            except:
                print("Digite uma opção válida!")
                return
            
            match op:
                case 1:
                    self.entradaDeDados()
                case 2:
                    self.listaDados()
                case 3:
                    self.folhaReajustada()
                case 0:
                    pass
                case _:
                    print("Opção Inválida")
        
            if(op == 0):
                return

            input("Pressione uma tecla para continuar...")

class ListaIdades(AnaliseDados):
    
    def __init__(self):
        super().__init__(type(int))
        self.__lista = []        
    
    def entradaDeDados(self):
        '''
        Este método solicita a digitação de uma
        idade e o adiciona na lista de idades.
        '''

        idade = input(f"Digite a idade: ")
        try:
            idade = int(idade)
        except:
            print("Digite um valor válido!")
            return

        if idade <= 0:
            print("A idade deve ser maior do que 0!")
            return
        
        self.__lista.append(idade)
        print("Idade adicionada!")
    
    def mostraMediana(self):
        '''
        Este método ordena a lista e mostra o
        elemento que está na metade da lista
        '''

        if len(self.__lista) <= 0:
            return

        meio = (((len(self.__lista) + 1) // 2) - 1)
        self.__lista.sort()

        mediana = self.__lista[meio]

        if len(self.__lista) % 2 == 0:
            mediana = (self.__lista[meio] + self.__lista[meio + 1]) / 2

        print("A mediana da lista de idades é: ", mediana)
    
    def mostraMenor(self):
        '''
        Este método retorna o menos elemento da lista
        '''

        if len(self.__lista) <= 0:
            return

        print("A menor idade é: ", min(self.__lista))
    
    def mostraMaior(self):
        '''
        Este método retorna o maior elemento da lista
        '''

        if len(self.__lista) <= 0:
            return

        print("A maior idade é: ", max(self.__lista))

    def __str__(self):
        return '\n'.join(self.__lista)
    
    def listaDados(self):
        for index, idades in enumerate(self.__lista):
            print(f"{index + 1}. {idades}")

    def menu(self):
        while(True):
            os.system('cls' if os.name == 'nt' else 'clear')
            print("========== Menu ==========")
            print("[1] Incluir uma idade")
            print("[2] Listar idades")
            print("[0] Voltar")
            print()

            op = input("Digite uma opção -> ")
            try:
                op = int(op)
            except:
                print("Digite uma opção válida!")
                return
            
            match op:
                case 1:
                    self.entradaDeDados()
                case 2:
                    self.listaDados()
                case 0:
                    pass
                case _:
                    print("Opção Inválida")
            
            if(op == 0):
                return

            input("Pressione uma tecla para continuar...")
  
def main():
    nomes = ListaNomes()
    datas = ListaDatas()
    salarios = ListaSalarios()
    idades = ListaIdades()

    while(True):
        os.system('cls' if os.name == 'nt' else 'clear')
        print("========== Menu ==========")
        print("[1] Lista de Nomes")
        print("[2] Lista de Datas")
        print("[3] Lista de Salários")
        print("[4] Lista de Idades")
        print("[0] Sair")
        print()

        op = input("Digite uma opção -> ")
        try:
            op = int(op)
        except:
            print("Digite uma opção válida!")
            return
        
        match op:
            case 1:
                nomes.menu()
            case 2:
                datas.menu()
            case 3:
                salarios.menu()
            case 4:
                idades.menu()
            case 0:
                pass
            case _:
                print("Opção Inválida")
        
        if(op == 0):
            break
  
    print("Fim do teste!!!")

if __name__ == "__main__":
    main()
