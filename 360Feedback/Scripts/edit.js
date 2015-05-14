$(init);

function init() {
    var counter = $("#counter").val();
    var name = "student" + counter;
    var emailName = "email" + counter;
    var id = "id" + counter;

    $("#plus").click(function () {
        name = "student" + counter;
        emailName = "email" + counter;
        id = "id" + counter;
        $("#inputFields").append("<input type='text' name='" + name + "' placeholder='Student Name'>&nbsp;&nbsp;&nbsp;<input type='text' name='" + emailName + "' placeholder='Student E-mail'><br><br><input type='hidden' name='" + id + "' value='0'> ")
        $("#counter").val(counter + 1);
        console.log($("#counter").val());
        counter++;
    })
}