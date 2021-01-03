import sys
from github import Github
g = Github(sys.argv[1],sys.argv[2])

repos = g.get_user().get_repos()

r = None

for repo in repos:
    if repo.name == 'Care-CureHospital':
        r = repo
developers = None
for t in r.get_teams():
    if t.name =='Developers':
        developers = t

developers.set_repo_permission(r,sys.argv[3])
print("Changed")
print(sys.argv[3])
