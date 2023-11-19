import os
import json

DATA_FILE_PATH = 'data.txt'
ID = 1
tasks = []

def save_tasks():
    data_file = open(DATA_FILE_PATH, 'w')
    for task in tasks:
        data_file.write(f"{json.dumps(task)}\n")

def load_tasks():
    if(not os.path.exists(DATA_FILE_PATH)):
        return []
    
    data_file = open(DATA_FILE_PATH)
    data = data_file.readlines()

    task_list = []
    for task in data:
        task_list.append(json.loads(task))

    return task_list

def find_task():
    while(True):
        try:
            id = int(input("Digite o id da tarefa: "))
            break
        except:
            print("Digite um número por favor.")

    if id > len(tasks) or id < 0:
        return False
    
    return tasks[id - 1]

def register_task():
    global ID

    description = input("Digite a descrição da tarefa: ")
    new_task = {
        'id': ID,
        'description': description.capitalize(),
        'checked': False
    }

    ID += 1
    tasks.append(new_task)
    print("Tarefa Registrada!")

def list_tasks():
    for index, task in enumerate(tasks):
        print(f"{index + 1}. {task['description']} {('[x]' if task['checked'] else '[]')}")

def complete_task():
    chosen_task = find_task()
    if(not chosen_task or chosen_task['checked']):
        return False

    chosen_task['checked'] = True
    tasks.remove(chosen_task)
    tasks.insert(0, chosen_task)
    print(f"Tarefa '{chosen_task['description']}' concluída!")

    return True

def edit_task():
    task = find_task()
    if(not task):
        return False
    
    new_description = input("Digite a nova descrição da tarefa: ")
    task['description'] = new_description
    print("Tarefa alterada com sucesso!")

if __name__ == "__main__":
    op = -1
    tasks = load_tasks()
    ID = len(tasks) + 1

    while True:
        print("--------- Menu ---------")
        print("1. Inserir nova tarefa")
        print("2. Marcar uma tarefa como concluída")
        print("3. Editar uma tarefa")
        print("4. Listar tarefas")
        print("0. Salvar e Sair")
        print("------------------------")
        try:
            op = int(input("Digite uma opção: "))
        except:
            print("Por favor digite um número.")
                

        match op:
            case 1:
                register_task()
            case 2:
                list_tasks()
                complete_task()
            case 3:
                list_tasks()
                edit_task()
            case 4:
                list_tasks()
            case 0:
                save_tasks()
                quit()
            case _:
                print("Opção Inválida")