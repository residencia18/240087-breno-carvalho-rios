def listar_tarefas(tarefas):

    for id_tarefa, tarefa in enumerate(tarefas, start=1):
        print(f"{id_tarefa}. {tarefa['descricao']} {tarefa['status']}")

def registrar_tarefa(tarefas, descricao):

    nova_tarefa = {
        'descricao': descricao.capitalize(),
        'status': '[ ]'
    }

    tarefas.append(nova_tarefa)
    print("Tarefa registrada!!!")

def marcar_realizada(tarefas, id_tarefa):

    if 1 <= id_tarefa <= len(tarefas):

        tarefa = tarefas.pop(id_tarefa - 1)
        tarefa['status'] = '[x]'
        tarefas.insert(0, tarefa)
        print("Tarefa marcada como realizada!!!")

    else:

        print("ID de tarefa inválido.")

def editar_tarefa(tarefas, id_tarefa, nova_descricao):

    if 1 <= id_tarefa <= len(tarefas):

        tarefa = tarefas[id_tarefa - 1]
        tarefa['descricao'] = nova_descricao.capitalize()
        print("Tarefa editada!!!")

    else:

        print("ID de tarefa inválido.")

def main():

    lista_tarefas = []

    while True:

        print("\nMenu ToDoList:")
        print("1. Listar Tarefas")
        print("2. Registrar Tarefa")
        print("3. Marcar Tarefa como Realizada")
        print("4. Editar Tarefa")
        print("5. Sair")

        opcao = int(input("Escolha uma opção: "))

        if opcao == 1:

            listar_tarefas(lista_tarefas)

        elif opcao == 2:

            descricao_tarefa = input("Insira a descrição da nova tarefa: ")
            registrar_tarefa(lista_tarefas, descricao_tarefa)

        elif opcao == 3:

            id_tarefa = int(input("Insira o ID da tarefa a ser marcada como realizada: "))
            marcar_realizada(lista_tarefas, id_tarefa)

        elif opcao == 4:

            id_tarefa = int(input("Insira o ID da tarefa a ser editada: "))
            nova_descricao = input("Insira a nova descrição da tarefa: ")
            editar_tarefa(lista_tarefas, id_tarefa, nova_descricao)

        elif opcao == 5:

            print("Saindo...")
            break

        else:

            print("Opção inválida. Tente novamente.")

if __name__ == "__main__":
    main()
