import json
import os

employee_DATA_PATH = 'employeeData.txt'

def registeremployee(employeeList):
    print("Cadastrar Novo Empregado: ")
    print("--------------------")

    name = input("Digite o nome do novo empregado: ")
    if(not name or not name.strip()):
        print("O nome não pode estar em branco!")
        return

    surname = input("Digite o sobrenome do novo empregado: ")
    if(not surname or not surname.strip()):
        print("O sobrenome não pode estar em branco!")
        return
    
    rg = input("Digite o rg do novo empregado (somente números): ")
    if(len(rg) != 10):
        print("O rg deve possuir 10 dígitos!")
        return
    
    birthYear = input("Digite o ano de nascimento do novo empregado: ")
    try:
        birthYear = int(birthYear)
    except:
        print("Por favor digite um ano válido!")
        return

    admissionYear = input("Digite o ano de admissão do novo empregado: ")
    try:
        admissionYear = int(admissionYear)
    except:
        print("Por favor digite um ano válido!")
        return
    
    salary = input("Digite o salário do novo empregado: ")
    try:
        salary = float(salary)
    except:
        print("Por favor digite um salário válido!")
        return
    
    newemployee = {
        'name': name,
        'surname': surname,
        'birthYear': birthYear,
        'rg': rg,
        'admissionYear': admissionYear,
        'salary': salary,
    }

    employeeList.append(newemployee)
    print("Empregado Cadastrado com Sucesso!")

def listemployees(employeeList):
    print("Lista de Empregados: ")
    print("--------------------")

    for index, employee in enumerate(employeeList):
        if((index + 1) % 11 == 0):
            input("Pressione uma tecla para ver mais resultados...")
            
        print(toString(employee))

def toString(employee):
    return f"{employee['name']} {employee['surname']} - R$ {'{:.2f}'.format(employee['salary'])}"

def Reajusta_dez_porcento(employeeList):
    for employee in employeeList:
        employee['salary'] *= 1.1
    
    print("Salários Reajustados em 10%")

def readData():
    if(not os.path.exists(employee_DATA_PATH)):
        return []
    
    employeeData = open(employee_DATA_PATH)        
    
    data = []
    jsonData = employeeData.readlines()

    for employee in jsonData:
        data.append(json.loads(employee))

    return data

def saveData(employeeList):
    employeeData = open(employee_DATA_PATH, 'w')

    for employee in employeeList:
        employeeData.write(f"{json.dumps(employee)}\n")

def showMenu():
    print("----------Menu----------")
    print("1. Cadastrar Empregado")
    print("2. Listar Empregados")
    print("3. Reajustar Salários (10%)")
    print("0. Sair")
    print("------------------------")

def main():
    employeeList = readData()

    while True:
        showMenu()
        op = input("Digite uma opção: ")
        try:
            op = int(op)
        except:
            print("Por favor digite um número válido")

        match op:
            case 1:
                registeremployee(employeeList)
            case 2:
                listemployees(employeeList)
            case 3:
                Reajusta_dez_porcento(employeeList)
            case 0:
                pass
            case _:
                print("Opção Inválida")

        saveData(employeeList)

        if(op == 0):
            break


if __name__ == "__main__":
    main()