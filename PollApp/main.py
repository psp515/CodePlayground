from fastapi import FastAPI
from enum import Enum

app=FastAPI()

# sample requests and queries
@app.get("/")
async def root():
    return {"message": "Hello World"}


from typing import List, Optional
from fastapi import HTTPException


# Placeholder data store
polls = {}


class Poll:
    def __init__(self, user: str, question: str):
        self.question = question
        self.owner = user
        self.votes = {}

    def update_vote(self, user: str, choice: str):
        self.votes[user] = choice
        return True

    def add_vote(self, user: str, choice: str):
        if user in self.votes:
            return False

        self.votes[user] = choice
        return True

    def remove_vote(self, user: str):
        if user in self.votes:
            self.votes.pop(user)

    def get_user_vote(self, user: str):
        return self.votes.get(user, None)

    def get_results(self) -> dict:
        results = {}
        for vote in self.votes.values():
            results[vote] = results.get(vote, 0) + 1
        payload = self.get_poll()
        payload["voteCount"] = results
        return payload

    def get_poll(self) -> dict:
        return {
            "question": self.question,
            "votes": len(self.votes),
        }


@app.get("/polls")
async def get_polls():
    data = [x.get_poll() for x in polls.values()]
    return {"polls": data }


@app.post("/polls")
async def create_poll(user: str, question: str):
    if question in polls:
        raise HTTPException(status_code=400, detail="Poll already exists")

    polls[question] = Poll(user, question)
    return {"message": "Poll created successfully"}

@app.delete("/polls/{question}")
async def delete_poll(user: str, question: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")

    poll = polls[question]

    if poll.owner != user:
        raise HTTPException(status_code=4004, detail="Poll cannot be removed by you.")

    del polls[question]
    return {"message": "Poll deleted successfully"}

@app.get("/polls/{question}")
async def get_results(question: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")
    poll = polls[question]
    return poll.get_results()

@app.post("/polls/{question}/votes")
async def vote(question: str, user: str, vote: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")
    poll = polls[question]
    result = poll.add_vote(user, vote)

    if not result:
        return { "message": "User is not allowed to vote second time." }

    return {"message": "Vote casted successfully"}

@app.delete("/polls/{question}/votes/{user}")
async def vote(question: str, user: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")
    poll = polls[question]
    poll.remove_vote(user)
    return {"message": "Vote removed successfully"}


@app.get("/polls/{question}/votes/{user}")
async def vote(question: str, user: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")
    poll = polls[question]
    result = poll.get_user_vote(user)

    if result is None:
        return {"message": "User dit not voted for it"}

    return {"value": result}

@app.put("/polls/{question}/votes/{user}")
async def vote(question: str, user: str, vote: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")
    poll = polls[question]
    poll.update_vote(user, vote)

    return {"message": "Update vote successfully."}
