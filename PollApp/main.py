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

    def add_vote(self, user: str, choice: str):
        self.votes[user] = choice

    def remove_vote(self, user: str):
        if user in self.votes:
            self.votes.pop(user)

    def get_results(self) -> dict:
        results = {}
        for vote in self.votes.values():
            results[vote] = results.get(vote, 0) + 1
        return results


@app.post("/poll/create/")
async def create_poll(user: str, question: str):
    if question in polls:
        raise HTTPException(status_code=400, detail="Poll already exists")

    polls[question] = Poll(user, question)
    return {"message": "Poll created successfully"}


@app.put("/poll/{question}/vote/")
async def vote(question: str, user: str, vote: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")
    poll = polls[question]
    poll.add_vote(user, vote)
    return {"message": "Vote casted successfully"}


@app.delete("/poll/{question}/vote/")
async def vote(question: str, user: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")
    poll = polls[question]
    poll.remove_vote(user)
    return {"message": "Vote removed successfully"}


@app.get("/poll/{question}/results/")
async def get_results(question: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")
    poll = polls[question]
    return poll.get_results()


@app.delete("/poll/{question}/delete/")
async def delete_poll(user: str, question: str):
    if question not in polls:
        raise HTTPException(status_code=404, detail="Poll does not exist")

    poll = polls[question]

    if poll.owner != user:
        raise HTTPException(status_code=4004, detail="Poll cannot be removed by you.")

    del polls[question]
    return {"message": "Poll deleted successfully"}
