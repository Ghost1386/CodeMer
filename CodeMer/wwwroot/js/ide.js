let editor;

window.onload = function() {
    editor = ace.edit("editor");
    editor.setTheme("ace/theme/monokai");
    editor.session.setMode("ace/mode/csharp");
}

function changeLanguage() {

    let language = $("#languages").val();

    if(language == 'c#')editor.session.setMode("ace/mode/csharp");
}

function executeCode() {

    $.ajax({

        url: "/Home/Compiler",

        method: "POST",

        data: {
            Language: $("#languages").val(),
            Code: editor.getSession().getValue()
        },

        success: function(response) {
            $(".output").text(response)
        }
    })
}