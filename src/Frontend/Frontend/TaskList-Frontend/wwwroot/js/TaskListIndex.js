function addTask() {
    // Получаем значения полей из формы
    var taskId = document.getElementById('taskId').value;
    var taskText = document.getElementById('taskText').value;
    var taskStatus = document.getElementById('taskStatus').value;
    var taskCreated = document.getElementById('taskCreated').value;

    // Проверка на заполненность полей
    if (!taskId || !taskText || !taskStatus || !taskCreated) {
        alert('Заполните все поля задачи');
        return;
    }

    // Создаем новую строку с задачей и добавляем ее в список задач
    var taskRow = '<p>ID: ' + taskId + ', Текст: ' + taskText + ', Статус: ' + taskStatus + ', Дата создания: ' + taskCreated + '</p>';
    document.getElementById('taskList').innerHTML += taskRow;

    // Очищаем значения полей формы
    document.getElementById('taskId').value = '';
    document.getElementById('taskText').value = '';
    document.getElementById('taskStatus').value = '';
    document.getElementById('taskCreated').value = '';
}