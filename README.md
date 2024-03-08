Overview of core functionalities

○ Player movement and UI
The player is a prefab that is spawned and assigned a role (either infected
or uninfected). This role determines the player’s capabilities and the
availability of some UI elements. Equally, it determines what tasks the player
receives: with infected and uninfected having different goals.

○ Health, Downing, and Voting
The player has 100 health as their base value. As their health is drained, the
health display changes along a gradient from green to red. Once it reaches
zero, the play is “down”, and rotates 90 degrees. Once in this down state, a
vote is started, and each time a different player strikes them in some way
while they are down, a vote is added to their PlayerVote object, of which they
are the subject. If the number of votes exceeds the number of players
who did not vote, the player is permanently killed (and would be turned into a
spectator in the developed game). If the number of votes is less than or equal
to the number of players who did not vote, the vote is cancelled, the subject
player gets up and is restored to 50% health.

○ Tasks
To progress the game forward, the player must complete objectives. This
would either be to shorten or extend the day or night cycle, to collect
equipment or remove equipment and weapons from around the map, or to
make completing further objectives easier - with uninfected and infected
having opposing goals. We decided upon two main ways to complete these
objectives: tasks and minigames.
Tasks are listed in the ObjectiveWindow, toggled to appear or disappear from
the player’s UI by pressing ‘o’. Tasks are removed from the ObjectiveWindow
when they are completed and are added when a player triggers an event to
activate it. In some cases, these tasks will rarely disappear, such as
“kill all uninfected explorers” which would only disappear at the end
of the game. However, some may be recurring, such as the “collect bananas”
task which would disappear when the night section begins, and reappear at
the end, or if the infected player ran too low on bananas to execute
uninfected players.

○ Map and Collision
The player is greeted with a medium-sized map. It has multiple layers, each
accessed through stairs. There are distinct sections to the map: corridors,
outdoor, and indoor. There are obstacles such as pillars, and almost every room
has at least two ingress/egress points. The map would be further upgraded
with props, shadows, and other decorative pieces in future iterations of the
project.

○ Rudimentary Multiplayer Networking
Though we had little in the way of time to develop the multiplayer
functionality, we did get a basic system working, wherein a player may host a
game and other players may join as clients. This is an exciting advancement
in our game, as future iterations could build on this with user-friendly UI,
lobbies, and player-versus-player combat.


What should the player do?
  Players must complete several tasks to further their progress in the game.
  These tasks are not always compulsory for the completion of the game (such as
  “Collect Equipment to Protect Yourself”) but may instead be helpful guides on
  how best to play the game to secure a greater chance of victory.
  What is the purpose of the tasks in the game?
  
  The purpose of tasks, outside of guiding players on the best course to victory,
  is to incentivise team play and allow them to keep track of their progress
  within the game. Communicating with teammates on where you want to go
  and what you want to do is a sure-fire way to reinforce your innocence - even
  if you might not be.
  
  Equally, a player may choose to observe the actions of other players when
  their tasks are satisfied to their liking.
  
  How does TaskManager?Does cs script manage tasks?
    The task manager script handles the storage of tasks and their addition or
    removal to each player’s objective window. For each update, the script
    will check if each task needs to be updated by getting its needs update
    Boolean value. If this is the case, it will run through each player object,
    updating each object window with the new, updated tasks.
    
    Each task is an instance of the Task class, storing the taskName, for the infected,
    and a goal integer value. As well as this, it stores a needs update boolean -
    initialised as true - and a progress integer - initialised at 0.
    
    Each Interact() method that progresses a task does so by going through the
    list of tasks, finding the one with the taskName that matches their target, and
    calls the task’s IterateProgress() method, iterating progress by 1 and setting
    needsUpdate to true. This circles back around to the task manager, which
    recognises this change and updates it on the players’ objective window.


Voting System:
  The purpose of the voting system is the primary way for the uninfected to
  defeat the infected. Since the uninfected cannot get rid of the infected by
  killing them in their infected form - merely temporarily removing them from
  combat to later respawn at another point.
  The social deduction element of the game comes into play here, as both
  infected and uninfected may be voted off, and the only way to tell if the person
  who got voted off was infected or not is to continue playing the game (if it
  doesn’t cause victory or defeat of course).

Process of Voting:
  When a player gets downed - meaning they were in their human form and
  their health was at or below zero - a vote is initiated. Each player may cast
  one vote on the downed player by striking them in their downed state. Once
  the vote duration is over, the votes are compared against the number of
  players who did not vote. If the number of votes exceeds the number of
  players who did not vote, the player dies. Otherwise, the player leaves their
  downed state and gains 50% of their health back.
  Players may use the time before a vote to analyse the actions of other players
  and ensure they are not being suspicious, while infected explorers must
  remain inconspicuous.
  The voting system presents an interesting strategic, social-engineering
  challenge, as gathering enough information on your target while continuing to
  do tasks and not incriminating yourself is a challenging balancing act.

Different roles and abilities in the game:
  There are two roles: infected and uninfected. During the day phase, the role
  of the infected is to collect as many bananas as possible without getting
  discovered, while also collecting equipment and weapons to deny
  those supplies to the uninfected. Conversely, the uninfected spend the day
  phase collecting equipment and weapons to best prepare themselves
  for the night phase.
  During the night phase, the infected must transform into monkey forms
  and use their collected bananas to execute uninfected explorers, permanently
  killing them. The uninfected, however, must fight to temporarily kill the
  infected monkeys, and survive until the day.
  This isn’t a reality within the prototype, but the groundwork is there.
  Within the actual game, the players all share the same prefab entity, whose
  behaviour, objectives, and certain UI elements are determined by their role.
  The uninfected can move and interact with interactable objects
  around the map. The infected, while sharing the abilities of the uninfected, are
  also capable of transforming into their monkey form

The random assignment of roles:
  At the beginning of the game, the players are all defaulted to an uninfected
  state. Then, the game manager goes back through and randomly selects the
  number of players specified in the number of infected variable to have their
  roles changed to infected, unlocking the transform button and ability for them.

Major Challenges:

Overview of challenges faced during development:
  Some of the major challenges we faced during development were: Requirements
  challenges, architecture and design challenges, implementation challenges and reasons for
  non-functionality, testing challenges and teamwork and client management challenges.

Requirements Challenges:
  One of the biggest challenges we faced when it came to requirements was the amount of
  times we repeatedly revised scripts and components. This impacted us both negatively and
  positively, the positives we can take from this are that the game quality was improved each
  time it was revised as we were fixing issues and bugs that needed fixing. On the other hand,
  the biggest negative of this was that it increased the amount of time spent on each script and
  left us with less time to complete the other tasks.

How did we tackle it?
  The way we addressed these challenges was to prioritise our requirements, this meant that
  we would start with the most important tasks such as basic mechanics and map design and
  then move on to the less important tasks such as sounds and effects.

Architecture and Design Challenges:
Scalability and modularity concerns:
  Some of the challenges we faced in designing the game's architecture and structure were the
  scalability and modularity concerns. If the game were to grow in popularity, it would need to
  handle a larger number of concurrent players, additional content, and more complex social
  interactions. Designing the architecture to be scalable and modular ensures that the game
  can be easily expanded and optimised without requiring significant rework. This can be
  challenging due to the fact we would need to anticipate future requirements.

Integration of different components and scripts
  A social game typically involves various components, such as networking, user interfaces,
  game mechanics, and social features. Integrating these components smoothly and ensuring
  they work together was incredibly challenging. To be able to integrate these components 
  required careful planning and coordination between the team and a good understanding of
  how unity works, this was done by the tutorials and research done in the early stages of the
  project.

Balancing complexity and maintainability:
  Designing a game's architecture requires finding the right balance between complexity and
  maintainability. A more complex architecture may offer advanced features and better
  performance, but it can also be harder to maintain, debug, and update. Striking the right
  balance involves making trade-offs that align with the game's objectives and available
  resources.


Implementation Challenges and Reasons for Non-Functionality:
Specific issues related:
  Bugs or errors in the code
  Incompatibilities between scripts or components
  Unresolved dependencies or missing assets

Impact of these issues:
  Inability to demonstrate the game during the presentation
  Frustration and disappointment for the team and client

Strategies used to identify and resolve these issues:
  Rigorous testing and debugging
  Seeking assistance from experienced developers or online resources

Testing Challenges:
Insufficient test coverage:
  Ensuring that every aspect of the game is thoroughly tested is challenging. This includes
  testing various game mechanics, level designs and performance under different conditions.
  Not testing properly can result in undiscovered issues or bugs that can impact player
  experience.

Inability to reproduce certain issues consistently:
  Some bugs or issues may occur intermittently or only under specific conditions, making them
  difficult to reproduce consistently. This can impede the process of identifying the root cause
  of the problem and implementing a fix.

Time constraints limiting testing opportunities:
  As we were spending pretty much all of our time implementing scripts and code, we had
  limited time for testing. As a result, some issues may not be identified and resolved before
  the game's final stage, leading to potential bugs and errors.

Impact of these challenges on the game's quality:
Undetected bugs or issues:
  Insufficient testing or difficulty in reproducing issues can lead to undetected bugs or
  problems making their way into the final version of the game. This may result in a subpar
  player experience.

Difficulty in assessing the game's overall stability and performance:
  If the testing phase is hindered by time constraints or insufficient test coverage, it can be
  challenging to accurately assess the game's stability and performance across various
  devices and conditions. This can lead to unexpected issues arising in the final stage of the
  game.

Strategies used to address these challenges:
Automated testing tools:
  Using automated testing tools can help identify bugs and issues more efficiently and
  consistently. These tools can perform tests on specific components or aspects of the game,
  such as performance, functionality, or compatibility. This can allow us to catch issues that we
  may not find normally

Teamwork and Client Management Challenges:
  Communication difficulties among team members:
  Miscommunication or lack of communication can lead to misunderstandings, missed
  deadlines, and duplicated efforts.
  
  Differing opinions or ideas about the game's direction:
  If the team were to have conflicting views on the game's design, mechanics, or features, this
  could hinder progress and lead to disagreements.
  
  Managing client expectations and addressing their concerns:
  Balancing client expectations while maintaining the project's scope and timeline was
  challenging, particularly when faced with conflicting requests or feedback.

Impact of these challenges on the development process and team morale:
  Slow decision-making:
  Conflicting opinions and communication issues can slow down the decision-making process,
  leading to delays in the project and negatively affecting the development.
  
  Conflicts and misunderstandings within the team:
  Disagreements and miscommunications can lead to tension, affecting morale and potentially
  leading to reduced productivity or attrition.

Strategies used to overcome these challenges:
  Regular team meetings and updates:
  We had team meetings twice every week to keep updates on progress and to discuss as a
  team what we needed to do. This facilitated open communication and enabled the team to
  address any concerns or issues weekly
  
  Transparent communication with the client:
  Maintaining open and transparent communication with the client helped us manage their
  expectations and address concerns. Having meetings with the client every so often it
  allowed us to get a clearer understanding of what is it they want and how we should go
  about doing it.


Lessons Learned from the Development Process:
  ○ Importance of clear requirements and communication with the client
  ○ Necessity of a well-thought-out architecture and design
  ○ The value of thorough testing and debugging
  ○ The critical role of effective teamwork and collaboration

How these lessons can be applied to future projects:
  ○ Improved requirement gathering and client management
  ○ Incorporation of best practices in architecture and design
  ○ Adoption of a more rigorous testing methodology
  ○ Enhanced team communication and conflict resolution strategies

Strategies to Address the Challenges Faced:
  ○ Active engagement with the client to clarify requirements
  ○ Use of design patterns and best practices in architecture and coding
  ○ Prioritization of testing and test-driven development
  ○ Regular team meetings and updates to ensure alignment
  
How these strategies can be implemented in future projects:
  ○ Integration of these strategies into the team's development process
  ○ Continuous improvement through feedback and evaluation

  
