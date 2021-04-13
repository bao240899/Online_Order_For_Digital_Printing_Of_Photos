    $(function() {
        var $document   = $(document),
            selector    = '[data-rangeslider]',
            $inputRange = $(selector);

        // Example functionality to demonstrate a value feedback
        // and change the output's value.
        function valueOutput(element) {
            var value = element.value,
                output = element.parentNode.getElementsByTagName('output')[0];
            output.innerHTML = value;
        }
        for (var i = $inputRange.length - 1; i >= 0; i--) {
            valueOutput($inputRange[i]);
        };
        $document.on('change', selector, function(e) {
            valueOutput(e.target);
        });

        // Initialize the elements
        $inputRange.rangeslider({
            polyfill: false,
        });

        // Example functionality to demonstrate programmatic value changes
        $document.on('click', '#js-example-change-value button', function(e) {
            var $inputRange = $('input[type="range"]', e.target.parentNode),
                value = $('input[type="number"]', e.target.parentNode)[0].value;

            $inputRange.val(value).change();
        });

        // Example functionality to demonstrate destroy functionality
        $document
            .on('click', '#js-example-destroy button[data-behaviour="destroy"]', function(e) {
                $('input[type="range"]', e.target.parentNode).rangeslider('destroy');
            })
            .on('click', '#js-example-destroy button[data-behaviour="initialize"]', function(e) {
                $('input[type="range"]', e.target.parentNode).rangeslider({ polyfill: false });
            });
    });