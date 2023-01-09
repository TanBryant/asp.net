$(document).ready(function () {
    
    $('#listCat').change(function () {
        let id = $('#listCat').val();
        console.log("ID = " + id);
        $("#result").load("/Product/LoadProduct/" + id);
    });
});