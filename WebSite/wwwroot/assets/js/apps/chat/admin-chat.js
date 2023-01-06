(function () {

    $('.chat-list .contact').on('click', function () {
        changeView('#chat-content-views', '#chat-view');
        getUserInfoByUserId(this);
        getSetSendMessageForm(this);
        getMessagesByUserId(this);
    });
    
    function changeView(wrapper, view) {
        var wrapper = $(wrapper);
        wrapper.find('.view').removeClass('d-none d-flex');
        wrapper.find('.view').not(view).addClass('d-none');
        wrapper.find(view).addClass('d-flex');
    }
   
    function getUserInfoByUserId(element) {
        var id = $(element).attr("id");
        $("#user-info-partial").load("/Admin/Chat/GetConversationInfoPartial", { id: id });
    };
    function getSetSendMessageForm(element) {
        var id = $(element).attr("id");
        $("#send-message-partial").load("/Admin/Chat/GetSendMessagePartial", { id: id });
    };
    function getMessagesByUserId(element) {
        var id = $(element).attr("id");
        $("#messages-partial").load("/Admin/Chat/GetMessagesByConversationIdPartial", { id: id });
    };
})();
