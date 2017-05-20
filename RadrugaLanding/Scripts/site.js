$(document).ready(function () {
    var $fullPage = $('#fullpage');
    $fullPage.fullpage({
        sectionsColor: ['#30323a', ' #8e90d6', '#fafafa', '#fac676', '#fafafa', '#908fd5'],
        anchors: ['radruga', 'enter', 'horizons', 'quests', 'superhero', 'contacts'],
        navigation: true,
        resize: false,
        navigationPosition: 'right',
        navigationTooltips: $fullPage.data("names")
    });


    $(".appstore").click(function (e) {
        if (typeof (ga) !== "undefined") {
            ga('send', 'event', 'click', 'download_app', "appstore");
            appInsights.trackEvent("download_app", { store: "appstore", referrer: document.referrer });
        }
    });

    $(".windowsstore").click(function (e) {
        if (typeof (ga) !== "undefined") {
            ga('send', 'event', 'click', 'download_app', "windowsstore");
            appInsights.trackEvent("download_app", { store: "windowsstore", referrer: document.referrer });
        }
    });

    $(".googleplay").click(function (e) {
        if (typeof (ga) !== "undefined") {
            ga('send', 'event', 'click', 'download_app', "googleplay");
            appInsights.trackEvent("download_app", { store: "googleplay", referrer: document.referrer });
        }
    });

    $(".buttonFeedback").click(function () {
        $('#sendMessagePopup').bPopup();
    });


    $("#sendMessage").on("click", function () {
        var span = $(this);
        var txtField = $("#txtMessage");
        var message = txtField.val();
        if (validateMessage(message)) {

            $.ajax({
                url: txtField.attr("data-url"),
                type: 'POST',
                data: JSON.stringify({
                    Text: message
                }),
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    span.addClass("b-close");
                    span.text("Готово!");
                    $("#sendMessage").off("click");
                    $("#sendMessagePopup .error").css("display", "none");
                },
                error: function () {
                    $("#sendMessagePopup .error").css("display", "block");
                }
            });
        } else {
            $("#sendMessagePopup .error").css("display", "block");
        }
    });

    $("#testFlightForm").on("submit", function (e) {
        e.preventDefault();
        var form = $(this);
        var txtField = $("#testFlightEmail", form);
        var email = txtField.val();

        $.ajax({
            url: form.attr("data-url"),
            type: 'POST',
            data: JSON.stringify({
                Email: email
            }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                form.hide();
                form.parent().append("<span>Готово!</span>")
            }
        });
        return false;

    });

    function validateMessage(message) {
        return message.length < 1000;
    }
});