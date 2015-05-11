$(init);

function init() {
    var counter = $("#counter").val();
    var name = "student" + counter;
    var emailName = "email" + counter;

    $("#plus").click(function () {
        name = "student" + counter;
        emailName = "email" + counter;
        $("#inputFields").append("<input type='text' name='" + name + "' placeholder='Student Name'>&nbsp;&nbsp;&nbsp;<input type='text' name='" + emailName + "' placeholder='Student E-mail'><br><br>")
        $("#counter").val(counter + 1);
        console.log($("#counter").val());
        counter++;
    })
}