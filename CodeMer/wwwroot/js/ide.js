let editor;

window.onload = function() {
    editor = ace.edit("editor");
    editor.setTheme("ace/theme/one_dark");
    editor.session.setMode("ace/mode/csharp");
}

function executeCode() {
    $.ajax({

        url: "/Compiler/Compiler",

        method: "POST",

        data: {
            Code: editor.getSession().getValue()
        },

        success: function(response) {
            $(".output").text(response)
        }
    })
}