import json
import os

def obter_opcao():
    while True:
        try:
            opcao = int(input("Escolha uma opção: "))
            return opcao
        except ValueError:
            print("Entrada inválida. Por favor, insira um número inteiro.")

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

def salvar_tarefas_arquivo(tarefas, nome_arquivo='tarefas.json'):
    diretorio_atual = os.getcwd()
    caminho_arquivo = os.path.join(diretorio_atual, nome_arquivo)
    
    with open(caminho_arquivo, 'w') as arquivo:
        json.dump(tarefas, arquivo)

def carregar_tarefas_arquivo(nome_arquivo='tarefas.json'):
    diretorio_atual = os.getcwd()
    caminho_arquivo = os.path.join(diretorio_atual, nome_arquivo)

    if os.path.exists(caminho_arquivo):
        with open(caminho_arquivo, 'r') as arquivo:
            return json.load(arquivo)
    return []

def main():
    # Carregar tarefas do arquivo, se existirem
    lista_tarefas = carregar_tarefas_arquivo()

    while True:
        print("\nMenu ToDoList:")
        print("1. Listar Tarefas")
        print("2. Registrar Tarefa")
        print("3. Marcar Tarefa como Realizada")
        print("4. Editar Tarefa")
        print("5. Sair")

        try:
            opcao = obter_opcao()
        except KeyboardInterrupt:
            print("\nSaindo...")
            break

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
            salvar_tarefas_arquivo(lista_tarefas)
            print("Saindo...")
            break
        else:
            print("Opção inválida. Tente novamente.")

if __name__ == "__main__":
    main()
