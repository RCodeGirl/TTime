(function () {

    $('#contacts .contact').on('click', function () {
        $(this).parent().find('li.active').removeClass('active');
        $(this).addClass("active");

        getUserInfoByUserId(this);
        getSetSendMessageForm(this);
        getMessagesByUserId(this);
    });


    function getUserInfoByUserId(element) {
        var id = $(element).attr("id");
        $("#user-info-partial").load("/Chat/GetConversationInfoPartial", { id: id });
    };
    function getSetSendMessageForm(element) {
        var id = $(element).attr("id");
        $("#send-message-partial").load("/Chat/GetSendMessagePartial", { id: id });
    };
    function getMessagesByUserId(element) {
        var id = $(element).attr("id");
        $("#messages-partial").load("/Chat/GetMessagesByConversationIdPartial", { id: id });
    };
})();