// Amal Shaiju 2021-04-01

function showStatusMsg(success, msg, timer) {

    // show only if the bar is not in use
    if ($('.status-msg-bar').css("display") == "none")
    {
        if (success) {
            console.log('#status-msg');
            console.log('.status-msg-bar');

            try {
                // set the color scheme and logo 
                $("#failure-statusLogo").css({ 'display': 'none' })
                $("#success-statusLogo").css({ 'display': 'block' })
                $('.status-msg-bar').removeClass('alert alert-danger');
                $('.status-msg-bar').addClass('alert alert-success');
            }
            catch {

            }

            // set the text to show
            $('#status-msg').text(msg);


            // fade the status bar in 
            $('.status-msg-bar').fadeIn();

            // fade it out after 5 sec
            $('.status-msg-bar').delay(timer).fadeOut();
        }
        else {

            try {
                $("#failure-statusLogo").css({ 'display': 'block' })
                $("#success-statusLogo").css({ 'display': 'none' })
                $('.status-msg-bar').removeClass('alert alert-success');
                $('.status-msg-bar').addClass('alert alert-danger');
            }
            catch {

            }

            // set the text to show
            $('#status-msg').text(msg);

            // fade the status bar in 
            $('.status-msg-bar').fadeIn();

            // fade it out after 5 sec
            $('.status-msg-bar').delay(timer).fadeOut();

        }
    }
}