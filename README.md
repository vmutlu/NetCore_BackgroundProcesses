# Background Processes
Hangfire library use case project that makes it easy for us to create, execute and manage background jobs

# What is Hangfire

It is an open source library that makes it easy for us to create, execute and manage background jobs.

## Hangfire Configuration — Error Management — Security
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/133924319-f0906f30-3eb6-4aa7-8001-e9881492bb02.png"> <br>
</p>
When we run the project, when the Hangfire Dashboard page opens, there are Jobs — Retries — Recurring Jobs — Server tabs in the top menu.
Hangfire is a structure designed to make it easier for us to follow our background work. It can display in many categorized ways such as working, not working, working jobs. It can also intervene (start with trigger).
<br><br>

* <b> Jobs:</b>
It is the tab where we can follow all the processes included in the process with their status;
* <b> Retries:</b>
It is the tab where we see the repetitions of the defined jobs as a result of possible mistakes. It can be seen how many times a job is repeated. By default, the number of repetitions is 10.
* <b> Recurring Jobs:</b>
It is the tab where the recurring defined jobs are seen. Although there is a set repetition, it can be triggered at any time with the Trigger.
* <b> Servers:</b>
This is the tab where we can see the Hangfire servers used.

<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/133924357-114370b4-0130-4a56-a998-51e255878de0.png"> <br>
</p>

* <b> Enqueued:</b> next jobs
* <b> Scheduled:</b> scheduled jobs
* <b> Processing:</b> currently in process/running jobs
* <b> Succeeded:</b> successfully completed works
* <b> Failed:</b> failed jobs
* <b> Deleted:</b> deleted jobs
* <b> Awaiting:</b> shows jobs that are waiting for their turn.

## :pushpin: Sample Background Actions Scenario in this project

* After the user registers, we will send an e-mail (set time) to activate the user. (Delayed Job)
* We will make a backup of the database (Recurring Job) so that the system will repeat according to the specified time and time. We will read the information about where to take the backup from the appsettings.json file.

## Delayed Job Process and process steps
<p align="center">
<img src="https://user-images.githubusercontent.com/50150182/133924565-e1018a3d-c2de-4c82-9e9d-6e994174142b.png"> <br>
<img src="https://user-images.githubusercontent.com/50150182/133924581-a1724e32-0e9d-4068-91b7-6e1a2f8a7423.png"> <br>
<img src="https://user-images.githubusercontent.com/50150182/133924596-c4508bf4-28b3-47c9-a44d-f0a36240c269.png"> <br>
<img src="https://user-images.githubusercontent.com/50150182/133924622-fdf99346-dc4c-4801-ace5-e0d9fa522460.png"> 
</p>

* * *

## :pushpin: In Summary
I tried to convey my knowledge about creating, running and other processes with Hangfire as much as I know and learn. For more, you can visit the official site https://www.hangfire.io/
I hope it was useful. :wave:

## Give a Star! :star:
If you like or are using this project to learn or start your solution, please give it a star. Thanks!







