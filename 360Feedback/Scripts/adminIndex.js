$(init);

function init() {
    var counter = 0;
    var name = "student" + counter;
    var emailName = "email" + counter++;

    $("#inputFields").html("<input type='text' name='" + name + "' placeholder='Student Name'>&nbsp;&nbsp;&nbsp;<input type='text' name='" + emailName + "' placeholder='Student E-mail'>")

    $("#plus").click(function () {
        $("#inputFields").append("<br><input type='text' name='" + name + "' placeholder='Student Name'>&nbsp;&nbsp;&nbsp;<input type='text' name='" + emailName + "' placeholder='Student E-mail'>")
    })
}