<h1>xAPI Logger plugin for Unity</h1>

For detailed documentation and overview see https://adamburich.github.io/SGTAPLogger/

<div class="contents">
    <h1>SGTAPLogger Documentation</h1>

  <h2>Overview</h2>
  <p>
    <strong>SGTAPLogger</strong> is a C# library for logging and reporting user interactions and events to a Learning Record Store (LRS) using the xAPI (TinCan API) standard.
    It provides a modular framework for capturing, batching, and sending learning activity statements from applications such as educational platforms or interactive training systems.
    The project targets <strong>.NET Framework 4.8</strong> and uses the TinCan.NET library for xAPI communication.
  </p>

  <h2>Key Components</h2>
  <ul>
    <li>
      <strong>Logger</strong>: Manages the connection to the LRS, batching log statements, and sending them via xAPI. Provides methods to queue, batch, and dispatch statements efficiently.
    </li>
    <li>
      <strong>APIHandler</strong>: Handles higher-level API interactions, orchestrating the flow of data between the application and the Logger. Manages authentication, error handling, and response processing.
    </li>
    <li>
      <strong>JsonToTinCan</strong>: Utility for converting JSON-formatted data into TinCan <code>Statement</code> objects, enabling flexible integration with various data sources.
    </li>
    <li>
      <strong>SubTypes (MCQ, MCQSubmits, DragDropQuestion, etc.)</strong>: Represent specific types of learning activities or question formats. Encapsulate the logic for constructing xAPI statements relevant to their activity type.
    </li>
    <li>
      <strong>xCall</strong>: Provides abstractions or helpers for building and managing xAPI calls, simplifying the creation of complex statements.
    </li>
    <li>
      <strong>Unit Tests</strong>: The <code>SGTAPLoggerTest</code> project contains tests (e.g., <code>APIHandlerTests.cs</code>) to ensure reliability and correctness of the core components.
    </li>
  </ul>

  <h2>How It Works</h2>
  <ol>
    <li>
      <strong>Initialization</strong><br>
      Create a <code>Logger</code> instance with valid LRS credentials (username and password):
      <pre><code>var logger = new Logger("username", "password");</code></pre>
    </li>
    <li>
      <strong>Statement Creation</strong><br>
      Use the subtypes (e.g., <code>MCQ</code>, <code>DragDropQuestion</code>) or utility classes to construct xAPI statements, either directly or from JSON:
      <pre><code>var statement = JsonToTinCan.toStatement(jsonString);</code></pre>
    </li>
    <li>
      <strong>Logging</strong><br>
      Add statements to the logger's queue. The logger batches statements and sends them to the LRS when the queue reaches a threshold (e.g., 5 statements):
      <pre><code>logger.AddLogToQueue(statement);</code></pre>
      Alternatively, send a statement immediately:
      <pre><code>logger.DoSendAPI(statement);</code></pre>
    </li>
    <li>
      <strong>Integration</strong><br>
      Integrate the logger and subtypes into your application workflow to capture and report user interactions as xAPI statements.
    </li>
  </ol>

  <h2>Typical Usage Example</h2>
  <pre><code>// Initialize logger
var logger = new Logger("user", "pass");

// Create a statement (e.g., from a multiple-choice question)
var mcqStatement = MCQ.CreateStatement(userId, questionId, selectedOption);

// Log the statement
logger.AddLogToQueue(mcqStatement);
</code></pre>

  <h2>Extensibility</h2>
  <ul>
    <li>Add new subtypes for additional activity types.</li>
    <li>Customize batching and error handling in the <code>Logger</code>.</li>
    <li>Extend <code>APIHandler</code> for advanced API workflows.</li>
  </ul>
</div><!-- contents -->

For a tutorial on integration with non Cerebrum games see https://youtu.be/0uVHWmJ1gGk
