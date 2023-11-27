async function getCollections()
{
		const response = await fetch(
			'https://localhost:7089/api/v1/collections',
			{
				method: 'GET',
				headers: {
					'Accept': '*/*',
				}
			}
		);
		if (!response.ok) {
			throw new Error(`HTTP error! status: ${response.status}`);
		}
		return await response.json();
}
async function getNotes(collectionId) {

	var endPoint = collectionId === undefined
		? 'https://localhost:7089/api/v1/notes'
		: `https://localhost:7089/api/v1/notes?collectionId=${collectionId}`;

	const response = await fetch(
			
		endPoint,
		{
			method: 'GET',
			headers: {
				'Accept': '*/*',
			}
		}
	);
	if (!response.ok) {
		throw new Error(`HTTP error! status: ${response.status}`);
	}
	return await response.json();
}
async function getNote(id) {
	const response = await fetch(
		`https://localhost:7089/api/v1/notes/${id}`,
		{
			method: 'GET',
			headers: {
				'Accept': '*/*',
			}
		}
	);
	if (!response.ok) {
		throw new Error(`HTTP error! status: ${response.status}`);
	}
	return await response.json();
}
async function updateNoteRequest(id,title,description) {
	const response = await fetch(
		`https://localhost:7089/api/v1/notes/${id}`,
		{
			method: 'PUT',
			body: JSON.stringify({
				title: title,
				description: description
			}),
			headers: {
				'Accept': '*/*',
				'Content-Type': 'application/json'
			}
		}
	);
	
	return await response;
}
async function deleteNoteRequest(id) {
	const response = await fetch(
		`https://localhost:7089/api/v1/notes/${id}`,
		{
			method: 'DELETE',
			headers: {
				'Accept': '*/*',
			}
		}
	);
	if (!response.ok) {
		throw new Error(`HTTP error! status: ${response.status}`);
	}
}
async function createNoteRequest(collectionId, title, description)
{
	const response = await fetch(
		`https://localhost:7089/api/v1/notes`,
		{
			method: 'POST',
			body: JSON.stringify({
				collectionId: collectionId,
				title: title,
				description: description
			}),
			headers: {
				'Accept': '*/*',
				'Content-Type': 'application/json'
			}
		}
	)

	if (!response.ok) {
		throw new Error(`HTTP error! status: ${response.status}`);
	}
	return await response.json();
}



function createCollectionListElement(ul, title, id) {

	var li = document.createElement('li');

	li.addEventListener("click", function ()
	{
		var current = ul.querySelector("li.active");

		if (current != null) {
			current.className = current.className.replace(" active", "");
		}

		this.className += " active";

		renderNoteList(id);
	});

	li.Id = id;

	var a = document.createElement('a');
	a.classList.add('svg-icon');
	a.href = "#";

	var i = document.createElement('i');
	i.innerHTML = '<svg width="20" class="svg-icon" id="iq-main-3" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">< path stroke - linecap="round" stroke - linejoin="round" stroke - width="2" d = "M3 7v10a2 2 0 002 2h14a2 2 0 002-2V9a2 2 0 00-2-2h-6l-2-2H5a2 2 0 00-2 2z" /></svg >';

	var span = document.createElement('span');
	span.innerText = title;

	a.appendChild(i);
	a.appendChild(span);

	li.appendChild(a);
	ul.appendChild(li);
}

function createNoteListElement(tbody, id, title, description, createdTime, updatedTime)
{
	var tr = document.createElement('tr');

	var td1 = document.createElement('td');
	td1.innerText = title;
	td1.setAttribute("name","title");

	var td2 = document.createElement('td');
	td2.innerText = description;
	td2.setAttribute("name","description");

	var td3 = document.createElement('td');
	td3.innerText = new Date(createdTime).toLocaleString();
	td3.setAttribute("name", "createdTime");

	var td4 = document.createElement('td');
	td4.innerText = new Date(updatedTime).toLocaleString();
	td4.setAttribute("name", "updatedTime");

	var td5 = document.createElement('td');
	td5.innerHTML = '<div><a onClick="updateModule(this)" href="#" class="badge badge-success mr-3 edit-note" data-toggle="modal" data-target="#edit-note"><i class="las la-pen mr-0"></i></a><a onClick="deleteModule(this)" href="#" class="badge badge-danger" data-extra-toggle="delete" data-closest-elem="tr" data-extra-toggle="delete" data-closest-elem="tr" data-toggle="modal" data-target="#delete-note"><i class="las la-trash-alt mr-0"></i></a></div>';

	tr.Id = id;
	tr.appendChild(td1);
	tr.appendChild(td2);
	tr.appendChild(td3);
	tr.appendChild(td4);
	tr.appendChild(td5);

	tbody.appendChild(tr);
}

async function renderNoteList(collectionId)
{
	let notes = await getNotes(collectionId);

	const tbody = document.getElementById("tree-table-9").getElementsByTagName("tbody")[0];

	tbody.replaceChildren();

	for (let i = 0; i < notes.length; i++) {
		createNoteListElement(tbody, notes[i].id, notes[i].title, notes[i].description, notes[i].createdDate, notes[i].updatedAt);
	}
}

async function renderCollectionList() {

	let collections = await getCollections();

	const ul = document.getElementById("notebooks");

	for (let i = 0; i < collections.length; i++) {
		createCollectionListElement(ul, collections[i].title, collections[i].id);
	}
}


function deleteModule(el)
{
	var tr = el.parentNode.parentNode.parentNode;
	var module = document.getElementById("delete-note");
	module.Id = tr.Id;
}

function updateModule(el) {
	var tr = el.parentNode.parentNode.parentNode;
	var title = tr.querySelector('td[name="title"]').innerText;
	var description = tr.querySelector('td[name="description"]').innerText;

	var module = document.getElementById("edit-note");
	module.querySelector('input[data-id="title"]').value = title;
	module.querySelector('input[data-id="description"]').value = description;
	module.Id = tr.Id;
}

async function updateNote() {
	var module = document.getElementById("edit-note");
	var title = module.querySelector('input[data-id="title"]').value;
	var description = module.querySelector('input[data-id="description"]').value;

	var updateResponse = await updateNoteRequest(module.Id, title, description);

	if (!updateResponse.ok) {
		throw new Error(`HTTP error! status: ${updateResponse.status}`);
	}

	var getResponse = await getNote(module.Id);

	const tbody = document.getElementById("tree-table-9").getElementsByTagName("tbody")[0];

    for (let tr of tbody.children) {
        if (tr.Id === `${module.Id}`) {
			tr.querySelector('td[name="title"]').innerText = getResponse.title;
			tr.querySelector('td[name="description"]').innerText = getResponse.description;
			tr.querySelector('td[name="createdTime"]').innerText = new Date(getResponse.createdDate).toLocaleString();
			tr.querySelector('td[name="updatedTime"]').innerText = new Date(getResponse.updatedAt).toLocaleString();
            break;
        }
    }

	module.querySelector('div[data-id="cancelButton"]').click();
}

async function deleteNote()
{
	var module = document.getElementById("delete-note");

	await deleteNoteRequest(module.Id);

	const tbody = document.getElementById("tree-table-9").getElementsByTagName("tbody")[0];

	for (let tr of tbody.children)
	{
		if (tr.Id === `${module.Id}`)
		{
			tbody.removeChild(tr)
			break;
		}
	}

	module.querySelector('div[data-id="cancelButton"]').click();
}

async function createNote()
{
	var module = document.getElementById("new-note");

	var title = module.querySelector('input[data-id="title"]').value;
	var description = module.querySelector('input[data-id="description"]').value;
	var activeCollectionId = document.getElementById("notebooks").querySelector("li.active").Id;

	var response = await createNoteRequest(activeCollectionId, title, description);

	const tbody = document.getElementById("tree-table-9").getElementsByTagName("tbody")[0];

	createNoteListElement(tbody, response.id, response.title, response.description, response.createdDate, response.updatedAt);

	module.querySelector('div[data-id="cancelButton"]').click();
}




