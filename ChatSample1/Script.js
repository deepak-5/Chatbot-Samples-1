
const chatMessages = document.querySelector(".chat-messages");
const inputField = document.querySelector(".input-field");
const sendButton = document.querySelector(".send-button");

// Simulate a response from the chatbot
function sendBotMessage(message) {
  const newMessage = document.createElement("div");
  newMessage.classList.add("message", "bot");
  newMessage.innerHTML = `
          <div class="message-avatar bot-avatar">AI</div>
          <div class="message-content bot">${message}</div>
      `;
  chatMessages.appendChild(newMessage);
  chatMessages.scrollTop = chatMessages.scrollHeight; // Scroll to bottom
}

// Send a message when the user presses enter
inputField.addEventListener("keyup", (event) => {
  if (event.key === "Enter") {
    sendMessage();
  }
});

// Send a message when the user clicks the send button
sendButton.addEventListener("click", sendMessage);

function sendBotMessage(message, loadingMessageElement) {
  loadingMessageElement.innerHTML = `
  <div class="message-avatar bot-avatar">AI</div>
  <div class="message-content bot">${message}</div>
`;
  chatMessages.scrollTop = chatMessages.scrollHeight; // Scroll to bottom
}

function sendMessage() {
  const userMessage = inputField.value.trim();
  if (userMessage !== "") {
    // Display the user's message
    const newMessage = document.createElement("div");
    newMessage.classList.add("message", "user");
    newMessage.innerHTML = `
      <div class="message-avatar user-avatar">U</div>
      <div class="message-content user">${userMessage}</div>
  `;
    chatMessages.appendChild(newMessage);

    // Display the loading spinner
    const loadingMessage = document.createElement("div");
    loadingMessage.classList.add("message", "bot");
    loadingMessage.innerHTML = `
      <div class="message-avatar bot-avatar">AI</div>
      <div class="message-content bot">
          <div class="loading-spinner"></div>
      </div>
  `;
    chatMessages.appendChild(loadingMessage);
    chatMessages.scrollTop = chatMessages.scrollHeight; // Scroll to bottom

    // Simulate a chatbot response (replace with actual API call)
    setTimeout(() => {
      sendBotMessage(
        `You said: ${userMessage}. Let's chat!`,
        loadingMessage
      );
    }, 500); // Delay for 5 seconds

    inputField.value = ""; // Clear the input field
  }
}
