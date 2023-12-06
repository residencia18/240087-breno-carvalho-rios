class Tarefa {
    constructor(nome) {
        this.nome = nome;
    }
}

window.addEventListener('load', () => {
    listaTarefas =  carregaTarefas();
    for (tarefa of listaTarefas) {
        adicionaTarefaDOM(tarefa)
    }
});

document.getElementById('btn-add-tarefa').addEventListener('click', () => {
    let tarefa = new Tarefa(document.getElementById('tarefa').value);
    adicionaTarefaDOM(tarefa);
    adicionaTarefaNoStorage(tarefa);
    document.getElementById('form-adicionar-tarefa').reset();
});

function adicionaTarefaDOM(tarefa) {
    let listaTarefas = document.getElementById('listaTarefas');
    let tarefaLi = document.createElement('li');
    let deletar = document.createElement('button');
    let text = document.createElement('p');
    text.innerHTML = tarefa.nome;
    deletar.innerHTML = "X";
    deletar.addEventListener('click', () => {
        document.getElementById("listaTarefas").removeChild(tarefaLi);
        removeTarefaNoStorage(tarefa);
    });
    tarefaLi.appendChild(text);
    tarefaLi.appendChild(deletar);
    listaTarefas.appendChild(tarefaLi);
}

function adicionaTarefaNoStorage(tarefa) {
    listaTarefas =  carregaTarefas();
    listaTarefas.push(tarefa);
    localStorage.setItem("lista-tarefas", JSON.stringify(listaTarefas));
}

function removeTarefaNoStorage(tarefa) {
    listaTarefas =  carregaTarefas();
    listaTarefas.splice(listaTarefas.indexOf(tarefa), 1);
    localStorage.setItem("lista-tarefas", JSON.stringify(listaTarefas));
}

function carregaTarefas() {
    listaTarefas = localStorage.getItem("lista-tarefas");
    if(listaTarefas == null) {
        return [];
    }
    listaTarefas = JSON.parse(listaTarefas);
    return listaTarefas;
}