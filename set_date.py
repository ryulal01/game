import time

# Дата для всех коммитов
NEW_DATE = int(time.mktime(time.strptime("2025-12-10 11:56:01", "%Y-%m-%d %H:%M:%S")))

def update_dates(commit):
    commit.author_date = NEW_DATE
    commit.committer_date = NEW_DATE

