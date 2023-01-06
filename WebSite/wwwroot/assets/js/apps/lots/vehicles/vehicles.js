$(document).ready(function () {
    $('#type').change(function () {
        $('#mark option').remove();
        $.getJSON('/VehicleTools/GetVehicleMarks', { id: $('#type').val() }, function (marks) {
            $.each(marks, function () {
                $('#mark').append('<option value=' +
                    this.id + '>' + this.name + '</option>');
            });

            if ($('#type option:selected').text() === '-') {
                $('#model option').remove();
                $('#model').append('<option value=' +
                    this.id + '>' + '-' + '</option>');
            }
        });
    });

    $('#mark').change(function () {
        $('#model option').remove();
        $.getJSON('/VehicleTools/GetVehicleModels', { id: $('#mark').val() }, function (models) {
            $.each(models, function () {
                $('#model').append('<option value=' +
                    this.id + '>' + this.name + '</option>');
            });
        });
    });

    $('#type').change(function () {
        $('#drive-type option').remove();
        $.getJSON('/VehicleTools/GetDriveTypes', { id: $('#type').val() }, function (driveTypes) {
            $.each(driveTypes, function () {
                $('#drive-type').append('<option value=' +
                    this.id + '>' + this.name + '</option>');
            });
        });
    });

    $('#type').change(function () {
        $('#options option').remove();
        $.getJSON('/VehicleTools/GetVehicleOptions', { id: $('#type').val() }, function (options) {
            $.each(options, function () {
                $('#options').append('<option value=' +
                    this.id + '>' + this.name + '</option>');
            });
        });
    });

    $('#type').change(function () {
        $('#body-type option').remove();
        $.getJSON('/VehicleTools/GetBodyTypes', { id: $('#type').val() }, function (bodyTypes) {
            $.each(bodyTypes, function () {
                $('#body-type').append('<option value=' +
                    this.id + '>' + this.name + '</option>');
            });
        });
    });

    $('#type').change(function () {
        $('#transmission-type option').remove();
        $.getJSON('/VehicleTools/GetTransmissionTypes', { id: $('#type').val() }, function (transmissionTypes) {
            $.each(transmissionTypes, function () {
                $('#transmission-type').append('<option value=' +
                    this.id + '>' + this.name + '</option>');
            });
        });
    });


    $("#MaxBidValueInput").on({
        keyup: function () {
            formatCurrency($(this));
            convertCurrencyFieldToInt($('#MaxBidValue'), $('#MaxBidValueInput'));
        }
    });
    $("#MinPriceInput").on({
        keyup: function () {
            formatCurrency($(this));
            convertCurrencyFieldToInt($('#MinPrice'), $('#MinPriceInput'));
        }
    });
    $("#BuyNowPriceInput").on({
        keyup: function () {
            formatCurrency($(this));
            convertCurrencyFieldToInt($('#BuyNowPrice'), $('#BuyNowPriceInput'));
        }
    });
});