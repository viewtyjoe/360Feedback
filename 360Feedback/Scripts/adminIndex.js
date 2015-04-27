$(init);

function init() {
    var counter = 0;
    var name = "student" + counter;
    var emailName = "email" + counter;

    $("#inputFields").html("<input type='text' name='" + name + "' placeholder='Student Name'>&nbsp;&nbsp;&nbsp;<input type='text' name='" + emailName + "' placeholder='Student E-mail'>")

    $("#plus").click(function () {
        counter++;
        name = "student" + counter;
        emailName = "email" + counter;
        $("#inputFields").append("<br><input type='text' name='" + name + "' placeholder='Student Name'>&nbsp;&nbsp;&nbsp;<input type='text' name='" + emailName + "' placeholder='Student E-mail'>")
        $("#counter").val(counter + 1);
        console.log($("#counter").val());
    })
}