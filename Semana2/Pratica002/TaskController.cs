namespace Pratica002;

using System.Globalization;
class TaskController {
    List<Task> taskList;

    public TaskController(){
        this.taskList = new();
    }

    public void createTask(){
        Console.WriteLine($"Inserir Nova Tarefa:");
        Console.WriteLine($"Digite o título da nova tarefa: ");
        string? title = Console.ReadLine();
        Console.WriteLine($"Digite a descrição da nova tarefa: ");
        string? description = Console.ReadLine();
        Console.WriteLine($"Digite a data de expiração da nova tarefa (dd/mm/yyyy HH:mm):");
        string? dateInput = Console.ReadLine();

        if(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(dateInput)){
            Console.WriteLine($"Por favor preencha todos os dados!");
            return;
        }

        DateTime date;
        try {
            date = DateTime.ParseExact(dateInput, "d/M/yyyy H:m", CultureInfo.InvariantCulture);
        } catch {
            Console.WriteLine($"Data Inválida!");        
            return;
        }

        Task newTask = new(title, description, date);

        taskList.Add(newTask);
    }

    public void completeTask(){
        Console.WriteLine($"Concluir Tarefa:");
        int? index = findTask();

        if(index == null){
            return;
        }

        taskList.ElementAt(index.Value).Completed = true;
    }

    public void editTask(){
        Console.WriteLine($"Editar Tarefa:");        
        int? index = findTask();

        if(index == null){
            return;
        }

        Task task = this.taskList.ElementAt(index.Value);

        Console.WriteLine($"Digite o novo título da tarefa: ");
        string? title = Console.ReadLine();
        Console.WriteLine($"Digite a nova descrição tarefa: ");
        string? description = Console.ReadLine();
        Console.WriteLine($"Digite a nova data de expiração da tarefa (dd/mm/yyyy hh:mm): (Deixe em branco se não quiser editar)");
        string? dateInput = Console.ReadLine();
        
        if(!string.IsNullOrEmpty(title)){
            task.Title = title;
        }

        if(!string.IsNullOrEmpty(description)){
            task.Description = description;
        }

        DateTime date;
        if(!string.IsNullOrEmpty(dateInput)){    
            try {
                date = DateTime.ParseExact(dateInput, "d/M/yyyy H:m", CultureInfo.InvariantCulture);
                task.ExpirationDate = date;
            } catch {
                Console.WriteLine($"Data Inválida!");      
                return;
            }
        }
    }

    public void deleteTask(){
        Console.WriteLine($"Excluir Tarefa:");
        int? index = findTask();

        if(index == null){
            return;
        }

        taskList.RemoveAt(index.Value);
    }

    public void listTasks(){
        Console.WriteLine($"Lista de Tarefas:");
        for(int i = 0; i < taskList.Count; i++){
            Task task = taskList[i];
            Console.WriteLine($"{i + 1}. {task.toString()}");
            Console.WriteLine($"--------------------------");
        }
    }

    public void listTasks(bool taskState){
        List<Task> tasks = taskList.FindAll(task => task.Completed == taskState);

        Console.WriteLine($"Lista de Tarefas {(taskState ? "Concluídas" : "Pendentes")}:");
        for(int i = 0; i < tasks.Count; i++){
            Task task = tasks[i];
            Console.WriteLine($"{i + 1}. {task.toString()}");
        }
    }

    public void listTasks(List<Task> tasks){
        Console.WriteLine($"Lista de Tarefas:");
        for(int i = 0; i < tasks.Count; i++){
            Task task = tasks[i];
            Console.WriteLine($"{i + 1}. {task.toString()}");
        }
    }

    public int? findTask(){
        listTasks();
        Console.WriteLine($"Digite o número de uma tarefa: ");
        string? taskNumberInput = Console.ReadLine();

        if(string.IsNullOrEmpty(taskNumberInput)){
            Console.WriteLine($"Por favor preencha todos os dados!");
            return null;
        }

        int taskNumber;
        try {
            taskNumber = Int32.Parse(taskNumberInput) - 1;
        } catch {
            Console.WriteLine($"Por favor digite um número!");
            return null;
        }

        Task task;
        try{
            task = taskList.ElementAt(taskNumber);
        } catch {
            Console.WriteLine($"Por favor digite um número válido!");
            return null;
        }

        return taskNumber;
    }

    public void listTaskByKeyword(){
        Console.WriteLine($"Digite os termos da busca: ");
        string? prompt = Console.ReadLine();

        if(string.IsNullOrEmpty(prompt)){
            Console.WriteLine($"Por favor preencha todos os dados!");
            return;
        }

        string[] keywords = prompt.Split(' ');

        List<Task> filteredTasks = taskList.Where(
            task => keywords.All(
                    keyword => task.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase) || task.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                )
            ).ToList();

        listTasks(filteredTasks);
    }

    void sortAndShowTasks(bool desc = false){
        List<Task> sortedTaskList;

        sortedTaskList = this.taskList.OrderBy(task => task.ExpirationDate).ToList();

        if(desc){
            sortedTaskList = this.taskList.OrderByDescending(task => task.ExpirationDate).ToList();
        }

        this.listTasks(sortedTaskList);
    }

    void showStatistics(){
        List<Task> sortedTaskList = this.taskList.OrderBy(task => task.ExpirationDate).ToList();
        int pendingTasks = 0, completedTasks = 0;

        foreach(Task task in this.taskList){
            if(task.Completed){
                completedTasks++;
            } else {
                pendingTasks++;
            }
        }

        Console.WriteLine($"{completedTasks} tarefas concluídas.");
        Console.WriteLine($"{pendingTasks} tarefas pendentes.");
        Console.WriteLine($"--------------------------");        
        Console.WriteLine($"Última tarefa a vencer:\n{sortedTaskList.Last().toString()}");
        Console.WriteLine($"--------------------------");        
        Console.WriteLine($"Primeira tarefa a vencer:\n{sortedTaskList.First().toString()}");
    }

    public void showMenu(){
        Console.WriteLine($"----------Menu----------");
        Console.WriteLine($"1. Inserir Tarefa");
        Console.WriteLine($"2. Marcar Tarefa como Concluída");
        Console.WriteLine($"3. Editar Tarefa");
        Console.WriteLine($"4. Excluir Tarefa");
        Console.WriteLine($"5. Listar Tarefas");
        Console.WriteLine($"6. Listar Tarefas Concluídas");
        Console.WriteLine($"7. Listar Tarefas Pendentes");
        Console.WriteLine($"8. Buscar Tarefa");
        Console.WriteLine($"9. Listar Tarefas (mais antigas -> mais recentes)");
        Console.WriteLine($"10. Buscar Tarefa (mais recentes -> mais antigas)");
        Console.WriteLine($"11. Estatísticas de Uso");
        Console.WriteLine($"0. Sair");
    }

    public void run(){
        while(true){
            this.showMenu();

            Console.WriteLine($"Digite uma opção");
            string? opInput = Console.ReadLine();

            if(string.IsNullOrEmpty(opInput)){
                continue;
            }

            int op;
            try {
                op = Int32.Parse(opInput);
            } catch {
                Console.WriteLine($"Por favor digite um número!");
                continue;
            }

            switch(op){
                case 1: {
                    createTask();
                    break;
                }
                case 2: {
                    completeTask();
                    break;
                }
                case 3: {
                    editTask();
                    break;
                }
                case 4: {
                    deleteTask();
                    break;
                }
                case 5: {
                    listTasks();
                    break;
                }
                case 6: {
                    listTasks(taskState: true);
                    break;
                }
                case 7: {
                    listTasks(taskState: false);
                    break;
                }
                case 8: {
                    listTaskByKeyword();
                    break;
                }
                case 9: {
                    sortAndShowTasks();
                    break;
                }
                case 10: {
                    sortAndShowTasks(true);
                    break;
                }
                case 11: {
                    showStatistics();
                    break;
                }
                case 0: {
                    break;
                }
                default: {
                    Console.WriteLine($"Opção Inválida");      
                    break;
                }    
            }

            if(op == 0){
                break;
            }

            Console.WriteLine($"Pressione uma tecla para continuar...");
            Console.ReadLine();
        }
    }
}
