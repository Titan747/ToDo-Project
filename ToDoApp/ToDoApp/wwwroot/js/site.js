// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.



const uri = 'http://localhost:59451/api/todo';
let todolist = [];





function getToDos() {
    fetch(uri, {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*'
        },
    })
        .then(response => response.json())
        .then(data => _displaytodoList(data))
        .catch(error => console.error('Unable to get items.', error));
}



function addToDo() {
  
    const ToDo = {
        Description: document.getElementById('Description').value,
        IsDone: document.getElementById('IsDone').value
    };
    //Fetch API
    //axios
    //jquery ajax
    //angular http service
    fetch(uri, {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*'
        },
        body: JSON.stringify(ToDo)
    })
        .then(response => response.json())
        .then(() => {
            getToDos();
            ///addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}



function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}



function displayEditForm(id) {
  
    const item = todolist.find(item => item.Id === id);



    document.getElementById('editId').value = item.Id;
    document.getElementById('editDescription').value = item.Description;
    document.getElementById('editIsDone').value = item.IsDone;
    document.getElementById('editForm').style.display = 'block';
}



function updateItem() {
    const Id = document.getElementById('editId').value;
    const ToDo = {
        Id: document.getElementById('editId').value,
        Description: document.getElementById('editDescription').value,
        IsDone: document.getElementById('editIsDone').value
    };



    fetch(`${uri}/${Id}`, {
        method: 'PUT',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*'
        },
        body: JSON.stringify(ToDo)
    })
        .then(() => getToDos())
        .catch(error => console.error('Unable to update item.', error));



    closeInput();



    return false;
}



function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}



function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'to-do' : 'to-dos';



    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}



function _displaytodoList(data) {
 
    const tBody = document.getElementById('todolist');
    tBody.innerHTML = '';



    _displayCount(data.length);



    const button = document.createElement('button');



    data.forEach(item => {
        let lableforId = document.createElement('label');
        lableforId.innerHTML = item.Id;



        let lableforDescription = document.createElement('label');
        lableforDescription.innerHTML = item.Description;



        let lableforIsDone = document.createElement('label');
        lableforIsDone.innerHTML = item.IsDone;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.Id})`);



        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.Id})`);



        let tr = tBody.insertRow();



        let td1 = tr.insertCell(0);
        td1.appendChild(lableforId);

        let td2 = tr.insertCell(1);
        td2.appendChild(lableforDescription);



        let td3 = tr.insertCell(2);
        td3.appendChild(lableforIsDone);


        //let td2 = tr.insertCell(1);
        //let textNode = document.createTextNode(item.name);
        //td2.appendChild(textNode);



        let td5 = tr.insertCell(3);
        td5.appendChild(editButton);



        let td6 = tr.insertCell(4);
        td6.appendChild(deleteButton);
    });



    todolist = data;
}