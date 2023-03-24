function loginCode(key) {

    $.ajax({

        url: "/Auth/Login",

        method: "POST",

        data: {
            Email: 'email',
            Password: 'password'
        },

        success: function(response) {
            localStorage.setItem(Text(response))
        }
    })
}