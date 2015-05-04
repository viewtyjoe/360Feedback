
$(init);

function init() {
    $( "#tabs" ).tabs().addClass( "ui-tabs-vertical ui-helper-clearfix" );
    $("#tabs li").removeClass("ui-corner-top").addClass("ui-corner-left");

    var questionForms = $(".radioQuestion").size();
    var nameOfRadio;
    var associatedDesc;

    $(function () {
        var tooltips = $("[title]").tooltip({
            position: {
                my: "left top",
                at: "right+5 top-5"
            }
        });
    })

    $('input[type="radio"]:radio').change(function () {
        nameOfRadio = ($(this).attr('name'));
        associatedDesc = "#desc" + nameOfRadio.substr(8);
        $(associatedDesc).html($(this).data("text"));
        $(this).closest('tr').addClass("green");
        checkAll();
    }) 

    $('.ajaxForm').submit(function () {
        $.post("SaveResponse", $(this).serialize(), function () {
            $(this).find(".formSuccess").class = "text-success";
            $(this).find(".formSuccess").html("Successfully Saved!");
        }).error(function () {
            $(this).find(".formSuccess").class = "text-danger";
            $(this).find(".formSuccess").html("Not able to save!");
        });
    })
};

function checkAll() {
    var formCount = $("form").size() - 1;
    var answeredQuestionCount = $(".green").size();
    if (answeredQuestionCount == formCount) {
        $("#btnSave").prop("disabled", false);
    }
}

