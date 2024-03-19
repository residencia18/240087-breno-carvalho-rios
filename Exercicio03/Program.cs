using Exercicio03.Classes;

Worker worker1 = new Worker("Worker 1");
Worker worker2 = new Worker("Worker 2");
Thread thread1 = new Thread(worker1.Work);
Thread thread2 = new Thread(worker2.Work);
thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();
