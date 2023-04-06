

function deleteMassage(e) {

    debugger;
    let result = confirm("Вы уверены что хотите удалить студента");

    const xhr = new XMLHttpRequest();
    if (result) {
        try {
            xhr.open('Get', '/StudentAction/Delete/' + e);

            xhr.send();

            alert("удалось удалить студента")

        } catch (ec) {
            alert("не удалось удалить студента")
        }
    }
    else {
        alert("не удалось удалить студента")
    }
location.reload()
}

function Update() {
location.reload()
}