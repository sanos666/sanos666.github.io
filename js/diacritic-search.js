export function normalizeInput(inputElement) {
    if (!inputElement) return;

    const normalize = (text) => {
        if (!text) return '';
        return text.normalize('NFD').replace(/[\u0300-\u036f]/g, '');
    };

    // Listen to input events and normalize the value
    inputElement.addEventListener('input', (e) => {
        const normalized = normalize(inputElement.value);
        if (normalized !== inputElement.value) {
            // Update the input value
            inputElement.value = normalized;
            // Trigger input event for MatBlazor to detect the change
            inputElement.dispatchEvent(new Event('input', { bubbles: true }));
        }
    });

    // Also normalize on blur to ensure consistency
    inputElement.addEventListener('blur', (e) => {
        const normalized = normalize(inputElement.value);
        if (normalized !== inputElement.value) {
            inputElement.value = normalized;
            inputElement.dispatchEvent(new Event('input', { bubbles: true }));
        }
    });
}

export function hookMatBlazorAutocomplete() {
    // Wait for MatBlazor to render its input field
    const waitForInput = setInterval(() => {
        const inputs = document.querySelectorAll('.mdc-text-field__input');
        if (inputs.length > 0) {
            clearInterval(waitForInput);
            inputs.forEach(input => {
                // Only normalize the autocomplete search input in the header
                if (input.closest('.header-search')) {
                    normalizeInput(input);
                }
            });
        }
    }, 100);

    // Stop waiting after 5 seconds
    setTimeout(() => clearInterval(waitForInput), 5000);
}

// Auto-hook when the DOM is ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', hookMatBlazorAutocomplete);
} else {
    hookMatBlazorAutocomplete();
}



