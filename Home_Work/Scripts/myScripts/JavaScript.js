

function deleteMassage (e){
    let result = confirm("Вы уверены что хотите удалить студента");
    if (result) {
        open('/StudentApi/Delete/' + e)
    }
}