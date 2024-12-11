$.validator.addMethod("greaterthan", function (value, element, params) {
    var comparisonField = $(params).val();

    if (value && comparisonField) {
        var comparisonValue = parseFloat(comparisonField);
        var currentValue = parseFloat(value);
        return currentValue > comparisonValue;
    }

    return false;
}, "This value must be greater than the comparison field.");

$.validator.unobtrusive.adapters.add("greaterthan", ["comparisonproperty"], function (options) {
    var element = options.element;
    var comparisonProperty = options.params.comparisonproperty;

    options.rules["greaterthan"] = "#" + comparisonProperty;
    options.messages["greaterthan"] = options.message;
});