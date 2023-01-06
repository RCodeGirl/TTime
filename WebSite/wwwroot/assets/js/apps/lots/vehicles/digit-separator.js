function convertCurrencyFieldToInt(hidden, input) {
    $(hidden).val($(input).val().replace(/[^\d]/g, ""));
};


function formatNumber(n) {
    // format number 1000000 to 1,234,567
    return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
}

function formatCurrency(input) {
    // appends $ to value, validates decimal side
    // and puts cursor back in right position.

    // get input value
    var input_val = input.val();

    // don't validate empty input
    if (input_val === "") { return; }

    // add commas to number
    // remove all non-digits
    input_val = formatNumber(input_val);

    // send updated string to input
    input.val(input_val);
}