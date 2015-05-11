
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
        associatedDesc = "#" + nameOfRadio.replace("question", "desc");
        $(associatedDesc).html($(this).data("text"));
        $(this).closest('tr').addClass("green");
        checkAll();
    }) 
};

function checkAll() {
    var formCount = $("fieldset").size();
    var answeredQuestionCount = $(".green").size();
    if (answeredQuestionCount == formCount) {
        $("#btnSave").prop("disabled", false);
    }
}

