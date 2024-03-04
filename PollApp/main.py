from fastapi import FastAPI

app = FastAPI()


@app.get("/")
async def root():
    return {"message": "Hello World"}


global IDS
IDS = 1
POLLS = []


class Poll:
    def __init__(self, owner: str, question: str, answers: []):
        self.owner = owner
        self.question = question
        self.answers = answers
        self.votes = [[] for _ in range(len(answers))]
        global IDS
        IDS += 1
        self.id = IDS

    def user_votes(self, user: str, answer: int):
        for vote_users in self.votes:
            if user in vote_users:
                vote_users.remove(user)
                break
                
        
        

    def remove_vote(self, user: str):
        pass

    def update_vote(self, user: str, answer: int):
        self.user_votes(user, answer)

    def results(self):
        pass


@app.post("/v1/poll")
async def create_poll():
    pass


@app.get("/v1/poll/{id}")
async def create_poll():
    pass


@app.delete("/v1/poll/{id}")
async def remove_poll():
    pass


@app.post("/v1/poll")
async def create_poll():
    pass
