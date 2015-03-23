
$(init);

function init() {
    $( "#tabs" ).tabs().addClass( "ui-tabs-vertical ui-helper-clearfix" );
    $("#tabs li").removeClass("ui-corner-top").addClass("ui-corner-left");

    $('input[name="question1"]:radio').change(function () {
        $("#desc").html($('input[name=question1]:checked', '#radioQuestion').val());
    });
};

