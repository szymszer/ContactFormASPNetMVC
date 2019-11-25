// Random auto complete form
function test() {
    $('.form-control').each(function () {
        var rand = Math.floor(Math.random() * 100);
        if ($(this).prop("name") == "Email")
            $(this).val("Test" + rand + "@" + $(this).prop("name"));

        else if ($(this).prop("name") == "AreaOfInterest") {
            var randomOpt = Math.floor(Math.random($('select option').length - 1) * 10 + 1)
            $('select option')[randomOpt].selected = true
        }

        else if ($(this).prop("name") == "Phone") {
            var nb = "";
            for (i = 0; i < 9; i++)
                nb += Math.floor(Math.random() * 10);
            $(this).val(nb);
        }

        else
            $(this).val($(this).prop("name") + '#' + rand);
    })
}
